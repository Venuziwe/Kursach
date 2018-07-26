using System;
using System.Linq;
using System.Web.Mvc;
using Institut.Models;
using System.Web.Helpers;


namespace Institut.Controllers
{
    public class HomeController : Controller
    {
        NewContext db = new NewContext();

        public ActionResult Index()
        {
            var news = db.News;
            ViewBag.News = news;
            return View();
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(string FormHead, string FormDescription)
        {
            var CurrentDate = DateTime.Now;
            if ((FormHead != null) && (FormDescription != null))
            {
                db.News.Add(new New { Head = FormHead, Description = FormDescription, Date = CurrentDate });
                db.SaveChanges();

                int last_id = (from n in db.News select n.NewId).ToList().Last();

                WebImage photo = null;
                photo = WebImage.GetImageFromRequest();
                if (photo != null)
                {
                    photo.FileName = last_id.ToString();
                    photo.Resize(width: 250, height: 168, preserveAspectRatio: true, preventEnlarge: true);
                    photo.Save(@"~/Content/Images/" + photo.FileName);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DeleteNew()
        {
            var news = db.News;
            ViewBag.News = news;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteNew(int NewId = 0)
        {
            var news = db.News;
            ViewBag.News = news;
            New deletenew = db.News.Find(NewId);
            if (NewId != 0)
            {
                if (deletenew != null)
                {
                    var imageName = Request.MapPath(@"~/Content/Images/" + NewId + ".jpeg");
                    if (System.IO.File.Exists(imageName))
                    {
                        System.IO.File.Delete(imageName);
                    }
                    db.News.Remove(deletenew);
                    db.SaveChanges();
                }
            }
            return View();
        }

        public ActionResult ShowNew(int New_Id = 0)
        {
            ViewBag.New_Id = New_Id;

            var news = db.News;
            ViewBag.News = news;

            return View();
        }
    }
}