using CoreBlog.Entities.Concrete;
using CoreBlog.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.ViewComponents
{
    public class UserHeader: ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public UserHeader(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return View(new UserModel
            {
                User = user
            
            });

        }


    }
}
