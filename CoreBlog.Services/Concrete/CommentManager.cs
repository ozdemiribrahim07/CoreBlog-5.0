using AutoMapper;
using CoreBlog.DataLayer.Abstract;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Services.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Concrete;
using ProgrammersBlog.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Concrete
{
    public class CommentManager : ManagerBase, ICommentService
    {
        
        public CommentManager(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {

        }


        public async Task<IDataSonuc<CommentDto>> Get(int commentId)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);
            
            

            if (comment != null)
            {
                return new DataSonuc<CommentDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentDto
                {
                    Comment = comment,
                });
            }

            return new DataSonuc<CommentDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,  new CommentDto
            {
                Comment = null,
            });

        }



        public async Task<IDataSonuc<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId)
        {
            var result = await UnitOfWork.Comments.AnyAsync(c => c.Id == commentId);

            if (result)
            {
                var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);
                var commentUpdateDto = Mapper.Map<CommentUpdateDto>(comment);

                return new DataSonuc<CommentUpdateDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, commentUpdateDto);
            }

            else
            {
                return new DataSonuc<CommentUpdateDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, null);
            }

        }

        public async Task<IDataSonuc<CommentListDto>> GetAllAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(null, c => c.Blog);

            if (comments.Count > -1)
            {
                return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }

            return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,  new CommentListDto
            {
                Comments = null,
            });

        }

        public async Task<IDataSonuc<CommentListDto>> GetAllByDeletedAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => c.IsDeleted);

            if (comments.Count > -1)
            {
                return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }

            return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,  new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataSonuc<CommentListDto>> GetAllByNonDeletedAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => c.IsDeleted == false);

            if (comments.Count > -1)
            {
                return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }

            return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,  new CommentListDto
            {
                Comments = null,
            });

        }

        public async Task<IDataSonuc<CommentListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var comments = await UnitOfWork.Comments.GetAllAsync(c => !c.IsDeleted && c.IsActive , c => c.Blog);

            if (comments.Count > -1)
            {
                return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }

            return new DataSonuc<CommentListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,  new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataSonuc<CommentDto>> AddAsync(CommentAddDto commentAddDto)
        {
            var blog = await UnitOfWork.Blogs.GetAsync(b => b.Id == commentAddDto.BlogId);

            var comment = Mapper.Map<Comment>(commentAddDto);
            var addedComment = await UnitOfWork.Comments.AddAsync(comment);

            blog.CommentCount = await UnitOfWork.Comments.CountAsync(c => c.BlogId == blog.Id);

            await UnitOfWork.Blogs.UpdateAsync(blog);

            await UnitOfWork.SaveAsync();

            return new DataSonuc<CommentDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,  new CommentDto
            {
                Comment = addedComment,
            });

        }

        public async Task<IDataSonuc<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var oldComment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentUpdateDto.Id);

            var comment = Mapper.Map<CommentUpdateDto, Comment>(commentUpdateDto, oldComment);
            comment.EditedName = modifiedByName;

            var updatedComment = await UnitOfWork.Comments.UpdateAsync(comment);

            updatedComment.Blog = await UnitOfWork.Blogs.GetAsync(b => b.Id == updatedComment.BlogId);

            await UnitOfWork.SaveAsync();

            return new DataSonuc<CommentDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentDto
            {
                Comment = updatedComment,
            });
        }

        public async Task<IDataSonuc<CommentDto>> DeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);

            if (comment != null)
            {
                comment.IsDeleted = true;
                comment.EditedName = modifiedByName;
                comment.EditDate = DateTime.Now;
                var deletedComment = await UnitOfWork.Comments.UpdateAsync(comment);
                await UnitOfWork.SaveAsync();
                return new DataSonuc<CommentDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new CommentDto
                {
                    Comment = deletedComment,
                });

            }

            return new DataSonuc<CommentDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,  new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<ISonuc> HardDeleteAsync(int commentId)
        {
            var comment = await UnitOfWork.Comments.GetAsync(c => c.Id == commentId);

            if (comment != null)
            {
                await UnitOfWork.Comments.DeleteAsync(comment);
                await UnitOfWork.SaveAsync();

                return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success);
            }

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error);
        }

        public async Task<IDataSonuc<int>> CountAsync()
        {
            var commentsCount = await UnitOfWork.Comments.CountAsync();

            if (commentsCount > -1)
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, commentsCount);
            }

            else
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataSonuc<int>> CountByNonDeletedAsync()
        {
            var commentsCount = await UnitOfWork.Comments.CountAsync(c => !c.IsDeleted);

            if (commentsCount > -1)
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, commentsCount);
            }

            else
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataSonuc<int>> CountIsdeleted()
        {
            var comment = await UnitOfWork.Comments.CountAsync(c => c.IsDeleted == false);

            if (comment > -1)
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, comment);
            }

            return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, message: "HATA", -1);
        }
    }
}
