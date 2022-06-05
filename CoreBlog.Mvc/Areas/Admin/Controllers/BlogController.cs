using AutoMapper;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Entities.enumtypes;
using CoreBlog.Mvc.Areas.Admin.Models;
using CoreBlog.Mvc.Help;
using CoreBlog.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : BaseController
    {
        
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService , ICategoryService categoryService , IMapper mapper , IImageHelper imageHelper,UserManager<User> userManager)
            :base(userManager,mapper,imageHelper)
        {
            _blogService = blogService;
            _categoryService = categoryService;
         

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _blogService.GetAllNotDeleted();
            if (result.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success) return View(result.Data);
            return NotFound();
          
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var sonuc = await _categoryService.GetAllNotDeletedAndActive();
            if (sonuc.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
            {
                return View(
              new BlogAddModel
              {
                  Categories = sonuc.Data.Categories

              });
            }
            return NotFound();
          
        }


        [HttpPost]
        public async Task<IActionResult> Add(BlogAddModel blogAddModel)
        {
            if (ModelState.IsValid)
            {
                var blogdto = Mapper.Map<BlogAddDto>(blogAddModel);
                var image = await ImageHelper.Upload(blogAddModel.BlogTitle, blogAddModel.BlogImage, PictureType.Post);
                blogdto.Thumbnail = image.Data.FullName;

                var result = await _blogService.Add(blogdto, Logged.UserName , Logged.Id);
                if (result.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
                {
                   
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
                return RedirectToAction("Index", "Blog");

            }
            var category = await _categoryService.GetAllNotDeletedAndActive();
            blogAddModel.Categories = category.Data.Categories;
            return View(blogAddModel);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int blogId)
        {
            var blog = await _blogService.GetBlogUpdate(blogId);
            var category = await _categoryService.GetAllNotDeletedAndActive();

            if (blog.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success && category.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
            {
                var updatemodel = Mapper.Map<BlogUpdateModel>(blog.Data);

                updatemodel.Categories = category.Data.Categories;
                return View(updatemodel);

            }

            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateModel blogUpdateModel)
        {
            if (ModelState.IsValid)
            {
                bool newimage = false;
                var oldimage = blogUpdateModel.Image;

                if (blogUpdateModel.BlogImageFile != null)
                {
                    var imageupload = await ImageHelper.Upload(blogUpdateModel.BlogTitle, blogUpdateModel.BlogImageFile, PictureType.Post);

                    blogUpdateModel.Image = imageupload.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success ? imageupload.Data.FullName : "userimages/default.png";

                    if (oldimage != "userimages/default.png")
                    {
                        newimage = true;

                    }

                    var blogdto = Mapper.Map<BlogUpdateDto>(blogUpdateModel);
                    var sonuc = await _blogService.Update(blogdto, Logged.UserName);

                    if (sonuc.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
                    {
                        if (newimage)
                        {
                            ImageHelper.Delete(oldimage);
                        }

                        return RedirectToAction("Index", "Blog");
                    }

                    else
                    {
                        ModelState.AddModelError("", sonuc.Message);
                    }
                }


            }
            var categorie = await _categoryService.GetAllNotDeletedAndActive();
            blogUpdateModel.Categories = categorie.Data.Categories;
            return View(blogUpdateModel);
        }
        
        [HttpPost]
        public async Task<JsonResult> Delete(int blogid)
        {
            var sonuc = await _blogService.Delete(blogid, Logged.UserName);

            var blogsonuc = JsonSerializer.Serialize(sonuc);

            return Json(blogsonuc);
        }



    }
}
