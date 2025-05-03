using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class BlogPostController : Controller
    {
        BlogAppEntities db = new BlogAppEntities();

        // GET: BlogPost
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
        public ActionResult Create(BlogPostController blogPost)
        {
            try
            {
                int maxid = db.BlogPosts.Count() > 0 ? db.BlogPosts.Max(a => a.PostID) + 1 : 1;
                BlogPost.postid = (maxid);

             
            }
            catch (Exception)
            {

                throw;
            }

            return View(blogPost);
        }
    }
}