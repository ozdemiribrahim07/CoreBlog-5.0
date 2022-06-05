using CoreBlog.Entities.Concrete;
using CoreBlog.Mvc.Areas.Admin.Models;
using CoreBlog.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        private readonly IBlogService blogService;
        private readonly UserManager<User> userManager;

        public HomeController(ICategoryService categoryService, ICommentService commentService, IBlogService blogService, UserManager<User> userManager)
        {
            this.categoryService = categoryService;
            this.commentService = commentService;
            this.blogService = blogService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var blogall = await blogService.GetAll();
            var categoriecount = await categoryService.CountIsdeleted();
            var commentcount = await commentService.CountIsdeleted();
            var blogcount = await blogService.CountIsdeleted();
            var usercount = await userManager.Users.CountAsync();


            return View(
                new DashboardModel
                {
                    BlogCount = blogcount.Data,
                    CategorieCount = categoriecount.Data,
                    CommentCount = commentcount.Data,
                    UserCount = usercount,
                    Blogs = blogall.Data

                });
        }
        


    }
}
