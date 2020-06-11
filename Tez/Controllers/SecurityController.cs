using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        int login;
        public ActionResult Login()
        {
            return View();
        }






        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)

        {
            db = FirestoreDb.Create("alzheimertakip-e1d1e");

            //DocumentReference docRef = db.Collection("users").Document("alovelace");
            //Dictionary<string, object> user = new Dictionary<string, object>
            //{
            //    { "First", "Ada" },
            //    { "Last", "Lovelace" },
            //    { "Born", 1815 }
            //};
            //docRef.SetAsync(user);
            //// GET: Security




            DocumentReference docRef = db.Collection("Hasta").Document(username);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                Dictionary<string, object> user = snapshot.ToDictionary();

                if (password == user["password"].ToString())
                {
                    ViewBag.Login = "True";
                    FormsAuthentication.SetAuthCookie(username, true);
                    if (user["role"].ToString() == "A")
                        return Redirect("/Home/Admin");
                    else
                        return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Login = "Kullanıcı adı veya şifre yanlış";
                    return Redirect("/Security/Login");
                }
            }
            else
            {
                ViewBag.Login = "Kullanıcı adı veya şifre yanlış";
                return Redirect("/Security/Login");
            }


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