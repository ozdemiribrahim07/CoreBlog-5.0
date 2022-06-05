using CoreBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class BlogAddDto
    {
        [DisplayName("Blog Başlık")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalı.")]
        [MaxLength(120 , ErrorMessage = "{0} {1} karakterden fazla olmamalı." )]
        [MinLength(2 , ErrorMessage = "{0} {1} karakterden az olmamalı." )]
        public string BlogTitle { get; set; }

        [DisplayName("Blog İçerik")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalı.")]
        [MinLength(50, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        public string BlogContent { get; set; }

        [DisplayName("Blog Tarih")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalı.")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Blog Resim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılmamalı.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(6, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
