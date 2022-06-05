using CoreBlog.Entities.Dtos;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataSonuc<CommentDto>> Get(int commentId);
        Task<IDataSonuc<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId);
        Task<IDataSonuc<CommentListDto>> GetAllAsync();
        Task<IDataSonuc<CommentListDto>> GetAllByDeletedAsync();
        Task<IDataSonuc<CommentListDto>> GetAllByNonDeletedAsync();
        Task<IDataSonuc<CommentListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataSonuc<CommentDto>> AddAsync(CommentAddDto commentAddDto);
        Task<IDataSonuc<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName);
        Task<IDataSonuc<CommentDto>> DeleteAsync(int commentId, string modifiedByName);
        Task<ISonuc> HardDeleteAsync(int commentId);
        Task<IDataSonuc<int>> CountAsync();
        Task<IDataSonuc<int>> CountIsdeleted();
        Task<IDataSonuc<int>> CountByNonDeletedAsync();

    }
}
