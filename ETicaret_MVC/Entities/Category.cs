using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret_MVC.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Kategori Adı")]
        //[StringLength(100)]
        [StringLength(maximumLength: 20, ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]//uyarı mesajı
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }

}
