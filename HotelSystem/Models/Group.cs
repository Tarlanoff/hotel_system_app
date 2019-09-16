using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Qrupun Adını daxil edin"), MaxLength(50, ErrorMessage = "Qrup Adı 50 simvoldan uzun ola bilməz")]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}