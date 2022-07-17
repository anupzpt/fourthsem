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
            var Enrollment = db.Enrollments.ToList();
            return View(Enrollment);
        }
       
        

        public ActionResult Status(int Id)
        {
            Enrollment data = db.Enrollments.Find(Id);
            
            //db.Enrollments.Remove(data);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}