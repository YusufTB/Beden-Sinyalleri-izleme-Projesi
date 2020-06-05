using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tez.Models
{
    public class User 
    {
        public int userId { get; set; }      
        public string userName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        // GET: UserModel
        public class UserInit
        {
            public static List<User> Init()
            {
                return new List<User>
                {
                    new User{userId=1,userName="ilk",password="12345",role="A"}
                };
            }
        }
    }
}