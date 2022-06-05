using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Mvc.Models;
using CoreBlog.Services.Abstract;
using CoreBlog.Shared.Utilitie.Extension;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView();
        }

       



    }
}
