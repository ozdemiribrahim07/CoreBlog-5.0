using CoreBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.Models
{
    public class CommentUpdateModel
    {
        public string CommentUpdatePartial { get; set; }
        public CommentDto CommentDto { get; set; }

        public CommentUpdateDto CommentUpdateDto { get; set; }
    }
}
