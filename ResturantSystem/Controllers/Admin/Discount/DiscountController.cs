using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var Categories = db.Categories.ToList();
            ViewBag.Categories = new SelectList(Categories, "FoodCategory", "FoodCategory");
            var productTables = db.ProductTables.ToList();
            ViewBag.productTables = new SelectList(productTables, "ProductName", "ProductName");
            return View();

        }

        [HttpPost]
        public ActionResult AddDiscount(DiscountTable recordsave)
        {
            db.DiscountTables.Add(recordsave);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            DiscountTable data = db.DiscountTables.Find(Id);

            return View(data);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditData(DiscountTable update)
        {

            // TODO: Add update logic here

            db.Entry(update).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDiscount(int Id)
        {
            DiscountTable data = db.DiscountTables.Find(Id);
            return View(data);
        }
        public ActionResult DeleteDiscountData(int Id)
        {
            DiscountTable data = db.DiscountTables.Find(Id);
            db.DiscountTables.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}