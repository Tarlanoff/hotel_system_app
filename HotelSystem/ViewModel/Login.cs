using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelSystem.ViewModel
{
    public class Login
    {
        [Display(Name = "E-poçt")]
        [Required(ErrorMessage = "E-poçt boş ola bilməz"), MaxLength(50, ErrorMessage = "E-poçt 50 simvoldan uzun ola bilməz")]
        public string Email { get; set; }


        [Display(Name = "Şifrə")]
        [Required(ErrorMessage = "Şifrə boş ola bilməz"), MaxLength(100, ErrorMessage = "Şifrə 100 simvoldan uzun ola bilməz")]
        public string Password { get; set; }
    }
}