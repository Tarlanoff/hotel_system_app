using HotelSystem.Data;
using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelSystem.Helper
{
    public class AuthLogin : ActionFilterAttribute
    {
        private HotelContext context;
        public AuthLogin()
        {
            context = new HotelContext();
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Request.Cookies["cookie"] == null)
            {
                filterContext.Result = new RedirectResult("/home");
                return;
            }

            string token = HttpContext.Current.Request.Cookies["cookie"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.token == token);

            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "Index" }
               });
            }


        }
    }
}