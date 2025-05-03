using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
         BlogAppEntities db = new BlogAppEntities();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogController blogController)
        {

            try
            {
                int maxid = db.BlogPosts.Count() >  0 ? db.BlogPosts.Max(a => a.PostID)+ 1:1;
                blogController.postid = maxid;
                db.BlogPosts.Add(blogController);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            return View(blogController);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}