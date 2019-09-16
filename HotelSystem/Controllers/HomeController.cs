using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.ViewModel;
using HotelSystem.Models;
using System.Web.Helpers;

namespace HotelSystem.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(u=> u.Email == login.Email);
                if(user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        var g = Guid.NewGuid().ToString();
                        user.token = g;
                        _context.SaveChanges();

                        Response.Cookies["cookie"].Value = user.token;
                        Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(1);
                        return RedirectToAction("index", "dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("Summary", "E-poçt və ya Şifrə səhvdir");
                }
            }
            return View("login");
        }
    }
}