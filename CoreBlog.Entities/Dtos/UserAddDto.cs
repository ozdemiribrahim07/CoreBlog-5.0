using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class UserAddDto
    {
            
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        public string Username { get; set; }
            
        [DisplayName("Mail")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        [DataType(DataType.EmailAddress)]
         public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Resim Ekleyiniz.")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

       
        public string Picture { get; set; }

    }
}
