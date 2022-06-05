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
    public class AdminMenu:ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminMenu(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()  //ViewViewComponent
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result; //async olamadığı için sonuna result ekledik.
            var role = _userManager.GetRolesAsync(user).Result;

            return View(new UserRolesModel
            {
                
                User = user,
                Roles = role

            });

        }



    }
}
