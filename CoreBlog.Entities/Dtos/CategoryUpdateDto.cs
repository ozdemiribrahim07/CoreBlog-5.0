using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        public string CategoryName { get; set; }


        [DisplayName("Kategori Açıklama")]
        [MaxLength(400, ErrorMessage = "{0} {1} karakterden fazla olmamalı.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalı.")]
        public string CategoryDesc { get; set; }

        [DisplayName("Aktiflik ?")]
        [Required(ErrorMessage = "{0} boş geçilmemeli.")]
        public bool IsActive { get; set; }

    }
}
