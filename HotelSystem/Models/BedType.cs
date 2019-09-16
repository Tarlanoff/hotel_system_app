using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class BedType
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Yataq adını daxil edin"),MaxLength(50,ErrorMessage ="Ad 50 simvoldan uzun ola bilməz")]
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}