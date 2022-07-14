using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            ViewBag.productList = new SelectList(productlist, "FoodCategory", "FoodCategory");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductTable product, HttpPostedFileBase SelectedImg)
        {
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            product.ProductImage = "~/uploads/" + file_name ;
            db.ProductTables.Add(product);
            db.SaveChanges();
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
        public ActionResult EditProduct(int Id)
        {
            var productlist = db.Categories.ToList();
            ViewData["productList"] = new SelectList(productlist, "FoodCategory", "FoodCategory");
            ProductTable data = db.ProductTables.Find(Id);
            return View(data);
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditProductData(ProductTable product, HttpPostedFileBase SelectedImg)
        {
            ProductTable data = db.ProductTables.Find(product.Id);
            data.ProductName = product.ProductName;
            data.ProductPrice = product.ProductPrice;
            data.ProductDetail = product.ProductDetail;
            data.FoodCategory = product.FoodCategory;
            if (SelectedImg != null)
            {
                string path = Server.MapPath("~/uploads");
                string file_name = SelectedImg.FileName;
                string new_path = path + "/" + file_name;
                if (Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                SelectedImg.SaveAs(new_path);
                data.ProductImage = "~/uploads/" + file_name;
            }
            db.Entry(data).State = EntityState.Modified;

            //db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }

        // GET: Product/Delete/5
        public ActionResult DeleteProduct(int Id)
        {
            ProductTable data = db.ProductTables.Find(Id);
            return View(data);
        }

        // POST: Product/Delete/5
     
        public ActionResult DeleteProductData(int Id)
        {
            ProductTable data = db.ProductTables.Find(Id);
            db.ProductTables.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }
    }
}
