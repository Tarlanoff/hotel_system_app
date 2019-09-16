using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad və soyadı daxil edin"),MaxLength(50, ErrorMessage = "Ad və soyad 50 simvoldan uzun ola bilməz")]
        [Display(Name ="Ad və soyad")]
        public string FullName { get; set; }


        [Display(Name = "E-poçt")]
        [Required(ErrorMessage = "E-poçt ünvanını daxil edin"), MaxLength(50, ErrorMessage = "E-poçt 50 simvoldan uzun ola bilməz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə boş ola bilməz"), MaxLength(100, ErrorMessage = "Şifrə 100 simvoldan uzun ola bilməz")]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }


        [Display(Name = "Vəzifə")]
        public int GroupId { get; set; }
        public string token { get; set; }

        public Group Group { get; set; }

        public List<Booking> Bookings { get; set; }


    }
}