
using CoreBlog.Mvc.Models;
using CoreBlog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.ViewComponents
{
    public class TopNews : ViewComponent
    {
        private readonly IBlogService _blogService;

        public TopNews(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var blog = await _blogService.GetAllLast3();

            return View(new TopNewsViewModel

            {
                Blogs = blog.Data.Blogs
            }) ;

        }

    }
}
