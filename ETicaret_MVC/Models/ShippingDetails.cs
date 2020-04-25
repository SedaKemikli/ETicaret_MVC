using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret_MVC.Models
{
    public class ShippingDetails
    {
        public string AdSoyad { get; set; }

        [Required(ErrorMessage ="Lütfen Adres Başlığını giriniz.")]
        public string AdresBaslıgı { get; set; }

        [Required(ErrorMessage = "Lütfen Adres bilgisini giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir bilgisini giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen İlçe bilgisini giriniz.")]
        public string Ilce { get; set; }

        [Required(ErrorMessage = "Lütfen Mahalle bilgisini giriniz.")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}