using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private NewsDBEntities db = new NewsDBEntities();

        public ActionResult Index()
        {
            var news = db.News
                .OrderByDescending(n => n.CreatedOn)
                .Take(6)
                .ToList();

            return View(news);
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

        public ActionResult GroupList()
        {
            var model = db.Groups.ToList();
            return PartialView("_GroupsPartial",model);
        }

        public ActionResult ShowNews(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Groups group = db.Groups.Find(id);

            if (group == null)
                return HttpNotFound();

            ViewBag.GroupTitle = group.Title;

            var model = db.News
                .Where(n => n.GroupId == id)
                .OrderByDescending(n=>n.CreatedOn)
                .ToList();

            return View(model);
        }

        public ActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
    }
}