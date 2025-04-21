using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Area.Accounts
{
   
    public class User_RegistrationController : Controller
    {

         BlogAppEntities db = new BlogAppEntities();

        // GET: User_Registration
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = HashPassword(model.PasswordHash);

                db.Users.Add(new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = hashedPassword
                });

                db.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        private string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}