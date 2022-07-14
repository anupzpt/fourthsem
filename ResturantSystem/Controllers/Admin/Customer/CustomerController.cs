using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.Admin.Customer
{
    public class CustomerController : Controller
    {
        ResturantsystemEntities db;
        public CustomerController()
        {
            db = new ResturantsystemEntities();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var Customer = db.CustomerTables.ToList();
            return View(Customer);
        }
        public ActionResult Status(int Id)
        {

            var Customer = db.CustomerTables.ToList();

            return View(Customer);
        }
    }
}