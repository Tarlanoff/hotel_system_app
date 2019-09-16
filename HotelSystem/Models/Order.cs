using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int MenuId { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public Room Room { get; set; }
        public Menu Menu { get;set; }
    }
}