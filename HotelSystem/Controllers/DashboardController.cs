using HotelSystem.Helper;
using HotelSystem.Models;
using HotelSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HotelSystem.Controllers
{
    [AuthLogin]
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Rooms.Include("BedType").OrderBy(r => r.Id).ToList();
            
            return View(list);
        }

        public ActionResult CheckOut()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            return View();
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["cookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cookie");
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("index", "home");
        }

    }
}