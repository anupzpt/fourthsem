
using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.Admin.Categories
{
    public class CategoryController : Controller
    {
        ResturantsystemEntities db;
        public CategoryController()
        {
            db = new ResturantsystemEntities();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<Category> all_data = db.Categories.ToList();
          
            return View(all_data);

        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddData(Category recordsave)
        {
            db.Categories.Add(recordsave);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Category/Create
       
        public ActionResult Create()
        {
            return View();
        }

        // GET: Category/Edit/5
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
        
        public ActionResult Deletedata(int Id)
        {
            Category record = db.Categories.Find(Id);
            db.Categories.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
