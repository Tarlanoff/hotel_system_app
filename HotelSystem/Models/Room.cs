using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Otaq Nömrəsi boş ola bilməz")]
        [Display(Name ="Otaq Nömrəsi")]
        public int Number { get; set; }

        public bool Status { get; set; }
        [Required(ErrorMessage = "Qiymət boş ola bilməz")]
        [Display(Name = "Qiymət")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Yetkin sayı boş ola bilməz")]
        [Display(Name ="Yetkin sayı")]
        public int AdultCapacity { get; set; }
        [Required(ErrorMessage = "Uşaq sayı boş ola bilməz")]
        [Display(Name = "Uşaq sayı")]
        public int ChildCapacity { get; set; }
        [Display(Name = "Yataq növü")]
        public int BedTypeId { get; set; }
        public BedType BedType { get; set; }
        [Required(ErrorMessage = "Otaq haqqında məlumat boş ola bilməz"), MaxLength(500,ErrorMessage ="Otaq haqqında məlumat 500 simvoldan uzun ola bilməz")]

        [Display(Name = "Təsvir")]
        public string Description { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<Order> Orders { get; set; }

    }
}