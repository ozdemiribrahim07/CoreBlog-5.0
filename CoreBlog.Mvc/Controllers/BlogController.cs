using CoreBlog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task< IActionResult> HomeDetail(int blogid)  // anasayfada tıklanan bloğa göre details sayfasını getirir.
        {
           
            var blog = await _blogService.Get(blogid);
            if (blog.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
            {
                return View(blog.Data);


            }
            return NotFound();
        }

    }
}
