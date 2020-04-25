using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret_MVC.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double Price { get; set; }
        [DisplayName("Ürün Adeti")]
        public int StockAmount { get; set; }
        [DisplayName("Ürün Fotoğrafı")]
        public string Image { get; set; }
        [DisplayName("Ürün mevcut mu?")]
        [Required]
        public bool IsActive { get; set; }
        [DisplayName("Anasayfada gösterilsin mi?")]
        [Required]
        public bool IsHome { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}