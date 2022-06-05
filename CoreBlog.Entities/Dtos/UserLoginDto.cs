using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class UserLoginDto
    {
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

        [DisplayName("Beni Hatırla")]
        public bool BeniHatırla { get; set; }



    }
}
