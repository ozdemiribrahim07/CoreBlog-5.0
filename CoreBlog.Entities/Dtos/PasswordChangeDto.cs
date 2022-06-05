using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class PasswordChangeDto
    {
       

        [DisplayName("Şu anki Şifreniz")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Tekrar Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyumlu değildir.")]
        public string RepeatPassword { get; set; }



    }
}
