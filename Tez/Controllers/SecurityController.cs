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
        public ActionResult Login(User model)
        {
            var u = UserInit.Init().FirstOrDefault(x => x.userName == model.userName && x.password == model.password);
            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(u.userName, true);
                return Redirect("/Home/Index");
            }
            return View();
        }
        public ActionResult Logout()
        {
            
             FormsAuthentication.SignOut();
             
            
            return Redirect("/Security/Login");
        }
    }
}