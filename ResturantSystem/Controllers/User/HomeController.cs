using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers
{
    public class HomeController : Controller
    {
        ResturantsystemEntities db;
        public HomeController()
        {
            db = new ResturantsystemEntities();
        }
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            return View(category);
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
       
    }
}