﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class ContactSendDto
    {

        [DisplayName("Adınız")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(60, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Mail Adresiniz")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Mail { get; set; }
        [DisplayName("Konu")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(125, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string SubjectDesc { get; set; }
        [DisplayName("Mesaj")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(1500, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır.")]
        [MinLength(20, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır.")]
        public string Message { get; set; }



    }
}
