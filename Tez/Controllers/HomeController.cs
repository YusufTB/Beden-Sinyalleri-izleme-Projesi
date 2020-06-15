using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tez.Controllers
{
    public class HomeController : Controller
    {
        FirestoreDb db;
        [Authorize]
        public ActionResult Index()
        { 
            return View();
        }
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> UserView()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            db = FirestoreDb.Create("alzheimertakip-e1d1e");
            DocumentReference docRef = db.Collection("Hasta").Document(username);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            Dictionary<string, object> user = snapshot.ToDictionary();
            ViewBag.username = user["username"];
            return View();
        }
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> Admin()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            db = FirestoreDb.Create("alzheimertakip-e1d1e");
            DocumentReference docRef = db.Collection("Hasta").Document(username);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            Dictionary<string, object> user = snapshot.ToDictionary();
            if (user["role"].ToString() == "A")          
                return View();
            else
                return Redirect("/Home/Index");
        }

        
        public ActionResult Register()
        {
            return View();
        }


        public async System.Threading.Tasks.Task<ActionResult> UpdateProfile()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            db = FirestoreDb.Create("alzheimertakip-e1d1e");
            DocumentReference docRef = db.Collection("Hasta").Document(username);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            Dictionary<string, object> user = snapshot.ToDictionary();
                   
            ViewData["dict"] = user;


            return View(ViewData);
            
        }






        public async System.Threading.Tasks.Task<ActionResult> UserNotes()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            db = FirestoreDb.Create("alzheimertakip-e1d1e");
            DocumentReference docRef = db.Collection("Hasta").Document(username);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            Dictionary<string, object> user = snapshot.ToDictionary();
            
            ViewBag.user = username;



            return View();
            
        }






        public ActionResult Dashboard()
        {
            return View();
        }

        
        public ActionResult DashboardView()
        {
            return View();
        }

        public ActionResult SinyalTakip()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult jsdeneme(string username)
        {
            
            return View();
        }

    }
}