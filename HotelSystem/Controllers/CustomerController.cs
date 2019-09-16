﻿using System;
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
    public class CustomerController : BaseController
    {
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Customers.OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
          



            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            
            if (ModelState.IsValid)
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

         
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}