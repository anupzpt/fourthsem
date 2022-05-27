using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.Admin.ContactUS
{
    public class ContactUSController : Controller
    {
        ResturantsystemEntities db;
        public ContactUSController()
        {
            db = new ResturantsystemEntities();
        }
        // GET: ContactUS
        public ActionResult Index()
        {
            List<ContactU> all_data = db.ContactUS.ToList();
            return View(all_data);
        }
    }
}