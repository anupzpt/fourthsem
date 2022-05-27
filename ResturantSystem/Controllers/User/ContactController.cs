using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.User
{
    public class ContactController : Controller
    {
        ResturantsystemEntities db;
        public ContactController()
        {
            db = new ResturantsystemEntities();
        }
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult SaveData(ContactU ContactU)
        {
            db.ContactUS.Add(ContactU);
            db.SaveChanges();
            //different controller bata garyo bhane action ra controller dubai dekhaune
            return RedirectToAction("Index", "Home");
        }
    }
}