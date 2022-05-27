using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.Admin
{
    public class AdminController : Controller
    {
        ResturantsystemEntities db;
        public AdminController()
        {
            db = new ResturantsystemEntities();
        }
        // GET: Admin
        public ActionResult Index()
        {
            List<Category> all_data = db.Categories.ToList();
            return View(all_data);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      
        // GET: Admin/Edit/5
        public ActionResult Edit(int Id)
        {
            Category data = db.Categories.Find(Id);
            
            return View(data);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditData(Category update)
        {
          
                // TODO: Add update logic here

                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int Id)
        {
            Category data = db.Categories.Find(Id);
            return View(data);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Deletedata(int Id)
        {
            Category record = db.Categories.Find(Id);
            db.Categories.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
    }
}
