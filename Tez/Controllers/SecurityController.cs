using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tez.Models;
using static Tez.Models.User;

namespace Tez.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult Login(string username)
        {   
                FormsAuthentication.SetAuthCookie(username, true);
                return Redirect("/Home/Index");
        }
        public ActionResult Logout()
        {
            
             FormsAuthentication.SignOut();
             
            
            return Redirect("/Security/Login");
        }
    }
}