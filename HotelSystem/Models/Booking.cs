using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Display(Name ="İstifadəçi")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "Giriş")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Çıxış")]
        public DateTime CheckOut { get; set; }
        [Display(Name = "Otağın Nömrəsi")]
        public int RoomId { get; set; }
        [Display(Name = "Qiymət")]
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Menü")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public Room Room { get; set; }
    }
}