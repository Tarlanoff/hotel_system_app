using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Data;
using HotelSystem.Models;
using HotelSystem.Helper;

namespace HotelSystem.Controllers
{
    
    public class BaseController : Controller
    {
        // GET: Base
        public readonly HotelContext _context;

        public BaseController()
        {
            _context = new HotelContext();

        }
    }
}