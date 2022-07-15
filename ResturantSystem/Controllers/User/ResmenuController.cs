using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.User
{
    public class ResmenuController : Controller
    {
        ResturantsystemEntities db;
        // GET: Resmenu
        public ResmenuController()
        {
            db = new ResturantsystemEntities();
        }
        public ActionResult Resmenu()
        {
            var category = db.Categories.ToList();
            ViewBag.category = new SelectList(category, "FoodCategory", "FoodCategory");
            var product = db.ProductTables.ToList();
            return View(product);
        }
    }
}