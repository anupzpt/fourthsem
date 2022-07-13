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
        public ActionResult Index()
        {
            return View();
        }
    }
}