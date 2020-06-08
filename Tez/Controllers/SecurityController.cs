using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Google.Cloud.Firestore;
using Tez.Models;
using static Tez.Models.User;

namespace Tez.Controllers
{
    public class SecurityController : Controller
    {
        FirestoreDb db;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            db = FirestoreDb.Create("alzheimertakip-e1d1e");
            
            DocumentReference docRef = db.Collection("users").Document("alovelace");
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "First", "Ada" },
                { "Last", "Lovelace" },
                { "Born", 1815 }
            };
            docRef.SetAsync(user);
            // GET: Security
            return View();

            //if (username == null)
            //{
            //    return View();
            //}
            //else
            //{
            //    FormsAuthentication.SetAuthCookie(username, true);
            //    return Redirect("/Home/Index");
            //}
            //if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            //{
            //    FormsAuthentication.SignOut();
            //    return View();
            //}
            //return Redirect("/Home/Index");
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();


            return Redirect("/Security/Login");
        }
    }
}
