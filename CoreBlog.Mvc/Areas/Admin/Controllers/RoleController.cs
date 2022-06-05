using AutoMapper;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Mvc.Help;
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
    public class RoleController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager,UserManager<User> userManager,IMapper mapper ,IImageHelper imageHelper):base(userManager, mapper,imageHelper)
        {
            _roleManager = roleManager;
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var role = await _roleManager.Roles.ToListAsync();

            return View(new RoleListDto
            {
                Roles = role

            }); 
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Assign(int userid)
        {

            var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userid);
            var role = await _roleManager.Roles.ToListAsync();

            var roles = await UserManager.GetRolesAsync(user);

            UserRoleDto userRoleDto = new UserRoleDto
            {
                Userid = user.Id,
                Username = user.UserName,

            };


            foreach (var item in role)
            {
                RoleDto roleDto = new RoleDto
                {
                    Roleid = item.Id,
                    RoleName = item.Name,
                    Has = roles.Contains(item.Name)
                };

                userRoleDto.RoleDto.Add(roleDto);

            }
            return PartialView("RolePartial", userRoleDto);
        }


    }
}
