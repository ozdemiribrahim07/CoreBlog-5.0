using CoreBlog.Entities.Dtos;
using CoreBlog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEMailService _eMailService;

        public ContactController(IEMailService eMailService)
        {
            _eMailService = eMailService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(ContactSendDto contactSendDto)
        {
            if (ModelState.IsValid)
            {
                var mail = _eMailService.GonderMail(contactSendDto);
                if (mail.SonucStatus == Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success)
                {
                    return View();


                }

            }

            return View(contactSendDto);
        }


    }
}
