using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.Product
{
    public class ProductController : Controller
    {
        ResturantsystemEntities db;
        public ProductController()
        {
            db = new ResturantsystemEntities();
        }
        // GET: Product
        public ActionResult ProductIndex()
        {
            
            var Product = db.ProductTables.ToList();
            return View(Product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult AddProduct()
        {
            var productlist = db.Categories.ToList();
            ViewBag.productList = new SelectList(productlist, "Id", "FoodCategory");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductTable product)
        {
            return RedirectToAction("ProductIndex");
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult EditProduct(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditProductData(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult DeleteProduct(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult DeleteProductData(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
