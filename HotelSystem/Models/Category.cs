using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategoriyanın adını daxil edin"), MaxLength(50,ErrorMessage ="Ad 50 simvoldan uzun ola bilməz")]
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
    }
}