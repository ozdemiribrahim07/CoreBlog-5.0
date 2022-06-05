using CoreBlog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int current = 1, int pagesize = 6 ) 
        {

            var bloglist = await _blogService.GetAllPageAsync(current,pagesize);
            return View(bloglist.Data);
        }


    }
}
