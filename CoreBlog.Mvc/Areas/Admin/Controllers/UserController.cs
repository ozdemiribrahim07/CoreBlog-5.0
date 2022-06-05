using AutoMapper;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Entities.enumtypes;
using CoreBlog.Mvc.Areas.Admin.Models;
using CoreBlog.Mvc.Help;
using CoreBlog.Shared.Utilitie.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _env;

        public UserController(UserManager<User> userManager, IWebHostEnvironment env, IMapper mapper , SignInManager<User> signInManager,  IImageHelper imageHelper):base(userManager,mapper, imageHelper)
        {
            
            _env = env;
            _signInManager = signInManager;
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var user = await UserManager.Users.ToListAsync();

            return View(new UserListDto
            {

                Users = user,
                SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
            });
        }


        [Authorize(Roles = "Admin,Editor")]
        public async Task<string> Upload(string username , IFormFile picture)
        {
            string root = _env.WebRootPath;
            string extension = Path.GetExtension(picture.FileName);
            DateTime date = DateTime.Now;
            string filename = $"{username}_{date.FullDateTime()}{extension}";

            var path = Path.Combine($"{root}/userimages", filename);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            return filename;
        }

        [Authorize(Roles = "Admin,Editor")]
        public bool DeleteImage(string picture)
        {

            string root = _env.WebRootPath;
            var filedelete = Path.Combine($"{root}/userimages", picture);
            if (System.IO.File.Exists(filedelete))
            {
                System.IO.File.Exists(filedelete);
                return true;
            }
            return false;
        }





        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Delete(int userid)
        {
            var kullanıcı = await UserManager.FindByIdAsync(userid.ToString());

            var result = await UserManager.DeleteAsync(kullanıcı);

            if (result.Succeeded)
            {
                var delete = JsonSerializer.Serialize(new UserDto
                {
                    Message = $"{kullanıcı.UserName} silinmiştir.",
                    SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,
                    User =kullanıcı
                });
                return Json(delete);
            }

            else
            {
                string message = String.Empty;

                foreach (var item in result.Errors)
                {
                    message = $"{item.Description}";
                }

                var error = JsonSerializer.Serialize(
                    
                    new UserDto
                {
                    Message = $"{kullanıcı.UserName} silinirken hata oluştu.\n{message}",

                    SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error,
                    User=kullanıcı
                });

                return Json(error);

            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return PartialView("UserAddPartial");
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                var upladImage = await ImageHelper.Upload(userAddDto.Username,userAddDto.PictureFile,PictureType.User);

                userAddDto.Picture = upladImage.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
                   ? upladImage.Data.FullName
                   : "userImages/defaultUser.png";

                var kullanıcı = Mapper.Map<User>(userAddDto);

                var result = await UserManager.CreateAsync(kullanıcı, userAddDto.Password);

                if (result.Succeeded)
                {
                    var userajaxadd = JsonSerializer.Serialize(new UserAddAjaxModel
                    {
                        UserDto = new UserDto
                        {
                            SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,
                            Message = $"{kullanıcı.UserName} eklenmiştir.",
                            User = kullanıcı
                        },

                        UserAddPartial = await this.RenderViewToStringAsync("UserAddPartial", userAddDto)

                    });

                    return Json(userajaxadd);

                }

                else
                {


                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }


                    var userajaxerror = JsonSerializer.Serialize(new UserAddAjaxModel
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("UserAddPartial", userAddDto)

                    });
                    return Json(userajaxerror);

                }

            }


            var userajaxstateerror = JsonSerializer.Serialize(new UserAddAjaxModel
            {
                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("UserAddPartial", userAddDto)

            });
            return Json(userajaxstateerror);

        }


        [HttpGet]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<PartialViewResult> Update(int userid)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == userid);

            var updatedto = Mapper.Map<UserUpdateDto>(user);
            return PartialView("UserUpdatePartial", updatedto);


        }


        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool newpicture = false;
                var olduser = await UserManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var oldpicture = olduser.Picture;

                if (userUpdateDto.PictureFile != null)
                {
                    userUpdateDto.Picture = await Upload(userUpdateDto.Username, userUpdateDto.PictureFile);
                    newpicture = true;

                }
                var updated = Mapper.Map<UserUpdateDto, User>(userUpdateDto, olduser);
                var sonuc = await UserManager.UpdateAsync(updated);
                if (sonuc.Succeeded)
                {
                    if (newpicture)
                    {
                        DeleteImage(oldpicture);
                    }
                    var updateviewmodel = JsonSerializer.Serialize(new UserUpdateAjaxModel
                    {
                        UserDto = new UserDto
                        {
                            SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,
                            Message = $"{updated.UserName} güncellenmiştir.",
                            User = updated
                            
                        },
                        UserUpdatePartial = await this.RenderViewToStringAsync("UserUpdatePartial", userUpdateDto)

                    });
                    return Json(updateviewmodel);

                }
                else
                {
                    foreach (var item in sonuc.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    var updateviewerrormodel = JsonSerializer.Serialize(new UserUpdateAjaxModel
                    {
                        UserUpdateDto = userUpdateDto,
                        UserUpdatePartial = await this.RenderViewToStringAsync("UserUpdatePartial", userUpdateDto)

                    });
                    return Json(updateviewerrormodel);
                }

            }
            else
            {
                var updateviewerrormodelstate = JsonSerializer.Serialize(new UserUpdateAjaxModel
                {
                    UserUpdateDto = userUpdateDto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("UserUpdatePartial", userUpdateDto)

                });
                return Json(updateviewerrormodelstate);
            }

        }


        [HttpGet]
        [Authorize]
        public async Task<ViewResult> UserChangeDetails()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);   // şuan ki kullanıı bilgilerini getiriyoruz.
            var updatedto = Mapper.Map<UserUpdateDto>(user);
            return View(updatedto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ViewResult> UserChangeDetails(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool newpicture = false;
                var olduser = await UserManager.GetUserAsync(HttpContext.User);
                var oldpicture = olduser.Picture;

                if (userUpdateDto.PictureFile != null)
                {
                    userUpdateDto.Picture = await Upload(userUpdateDto.Username, userUpdateDto.PictureFile);
                    if (oldpicture != "default.png")
                    {
                        newpicture = true;
                    }
                  

                }
                var updated = Mapper.Map<UserUpdateDto, User>(userUpdateDto, olduser);
                var sonuc = await UserManager.UpdateAsync(updated);
                if (sonuc.Succeeded)
                {
                    if (newpicture)
                    {
                        DeleteImage(oldpicture);
                    }
                    return View(userUpdateDto);

                }
                else
                {
                    foreach (var item in sonuc.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(userUpdateDto);
                }

            }
            else
            {
                return View(userUpdateDto);

            }

        }

        [HttpGet]
        [Authorize]
        public ViewResult ChangePassword()
        {
            return View("UserChangePassword");
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(PasswordChangeDto passwordChangeDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(HttpContext.User);
                var verified = await UserManager.CheckPasswordAsync(user, passwordChangeDto.Password);
                if (verified)
                {
                    var sonuc = await UserManager.ChangePasswordAsync(user, passwordChangeDto.Password, passwordChangeDto.NewPassword);
                    if (sonuc.Succeeded)
                    {
                        await UserManager.UpdateSecurityStampAsync(user);

                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, passwordChangeDto.NewPassword , true , false);
                        return View();
                    }
                    
                }
                return View(passwordChangeDto);

            }

            return View(passwordChangeDto);
        }
   



    }
}
