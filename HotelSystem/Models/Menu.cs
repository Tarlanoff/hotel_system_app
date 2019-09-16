using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yemək Adını daxil edin"), MaxLength(50, ErrorMessage = "Ad 50 simvoldan uzun ola bilməz")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Qiymət")]
        public decimal Price { get; set; }

        [Display(Name="Kategoriya")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<Order> Orders { get; set; }
    }
}