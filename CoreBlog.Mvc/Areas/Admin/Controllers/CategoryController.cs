using AutoMapper;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Mvc.Areas.Admin.Models;
using CoreBlog.Mvc.Help;
using CoreBlog.Services.Abstract;
using CoreBlog.Shared.Utilitie.Extension;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin,Editor")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService,UserManager<User> userManager , IMapper mapper, IImageHelper ımageHelper)
            :base(userManager,mapper,ımageHelper)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllNotDeleted();

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("CategoryAddPartial");
        }


        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto , Logged.UserName);

                if (result.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
                {
                    var categoryajax = JsonSerializer.Serialize(new CategoryAddAjaxModel
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("CategoryAddPartial" , categoryAddDto)
                        
                    });

                    return Json(categoryajax);
                }

            }
            var categoryajaxerror = JsonSerializer.Serialize(new CategoryAddAjaxModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("CategoryAddPartial", categoryAddDto)

            });

            return Json(categoryajaxerror);
        }


        [HttpPost]
        public async Task<JsonResult> Delete(int categoryid)
        {
            var result = await _categoryService.Delete(categoryid, Logged.UserName);
            var deleted = JsonSerializer.Serialize(result.Data);
            return Json(deleted);

        }


        [HttpGet]
        public async Task< IActionResult> Update(int categoryid)
        {
            var result = await _categoryService.GetUpdateDto(categoryid);
            if (result.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
            {
                return PartialView("CategoryUpdatePartial" , result.Data);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(categoryUpdateDto, Logged.UserName);

                if (result.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
                {
                    var categoryupdateajax = JsonSerializer.Serialize(new CategoryUpdateAjaxModel
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("CategoryUpdatePartial", categoryUpdateDto)

                    });

                    return Json(categoryupdateajax);
                }

            }
            var categoryajaxerror = JsonSerializer.Serialize(new CategoryUpdateAjaxModel
            {
                CategoryUpdatePartial = await this.RenderViewToStringAsync("CategoryUpdatePartial", categoryUpdateDto)

            });

            return Json(categoryajaxerror);
        }






    }
}
