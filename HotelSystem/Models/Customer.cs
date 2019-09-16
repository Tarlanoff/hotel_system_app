using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad və Soyadı daxil edin"), MaxLength(100, ErrorMessage = "Ad və Soyad 100 simvoldan uzun ola bilməz")]
        [Display(Name = "Ad və Soyad")]
        public string Fullname { get; set; }
        [Display(Name = "Müştəri Tipi")]
        public bool isAdult { get; set; }
    }
}