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
            var cart = db.AddToCarts.ToList();
            ViewBag.cart = cart.Count();
            var category = db.Categories.ToList();
            ViewBag.category = new SelectList(category, "FoodCategory", "FoodCategory");
            var product = db.ProductTables.ToList();
            return View(product);
          
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