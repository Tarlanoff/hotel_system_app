using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Models;
using System.Web.Helpers;
using HotelSystem.Helper;

namespace HotelSystem.Controllers
{
    [AuthLogin]
    public class UserController : BaseController
    {
       
        // GET: User
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Users.Include("Group").OrderByDescending(u => u.Id).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            return View(user);
        }


        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userr = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = userr;
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.Groups = _context.Groups.ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}