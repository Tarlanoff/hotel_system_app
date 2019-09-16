using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Models;
using HotelSystem.Data;
using HotelSystem.Helper;

namespace HotelSystem.Controllers
{
    [AuthLogin]
    public class OrderController : BaseController
    {
        // GET: Restorant
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Orders.Include("Room").Include("Menu").OrderByDescending(p => p.Id).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();
            return View();

        }
        [HttpPost]
        public ActionResult Create(Order Order)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;



            if (ModelState.IsValid)
            {
                _context.Orders.Add(Order);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();

        }
        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            Order restorantPrice = _context.Orders.Find(Id);

            if (restorantPrice == null)
            {
                return HttpNotFound();

            }
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();

            return View(restorantPrice);
        }

        [HttpPost]
        public ActionResult Edit(Order orders)
        {

            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {
                _context.Entry(orders).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();
            return View(orders);

        }


        public ActionResult Delete(int id)
        {
            Order ord = _context.Orders.Find(id);

            if (ord == null)
            {
                return HttpNotFound();
            }

            _context.Orders.Remove(ord);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}