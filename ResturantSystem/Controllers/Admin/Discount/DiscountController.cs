using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.Admin.Discount
{
    public class DiscountController : Controller
    {
        ResturantsystemEntities db;
        // GET: Discount
        public DiscountController()
        {
            db = new ResturantsystemEntities();
        }
        public ActionResult Index()
        {
            var discount = db.DiscountTables.ToList();
            return View(discount);
        }
     public ActionResult AddDiscount()
        {
            return View();
        }
    }
}