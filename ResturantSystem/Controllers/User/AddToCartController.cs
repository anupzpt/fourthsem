using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.User
{
    public class AddToCartController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TKCK2P7\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Resturantsystem");
        ResturantsystemEntities db;
       

        public AddToCartController()
        {
            db = new ResturantsystemEntities();
        }

        // GET: AddToCart
        public ActionResult Index()
        {
            List<AddToCart> all_data = db.AddToCarts.ToList();
            ViewBag.UserId = '1';
            return View(all_data);

        }
      
        public ActionResult Store(int Id)
        {
            var product = db.ProductTables.Find(Id);
            var cart = new AddToCart();
            cart.ProductId = Id;
            cart.ProductPrice = product.ProductPrice;
            cart.ProductName = product.ProductName;
            cart.Quantity = "1";
            //db.AddToCarts.Add(cart);
            //db.SaveChanges();
            con.Open();
            string query = "INSERT INTO dbo.AddToCart(ProductId,UserId,ProductName,ProductPrice,Quantity)VALUES(  '" + Id + "','" + Id + "','" + cart.ProductName + "','" + cart.ProductPrice + "','" + cart.Quantity + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult CartEdit(int Id)
        {
            AddToCart data = db.AddToCarts.Find(Id);
            return View(data);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditCart(AddToCart Id)
        {
            var Addtocart = db.AddToCarts.Find(Id);
            var cart = new AddToCart();
            con.Open();
            string query = "Update dbo.AddToCart set Quantity='" + cart.Quantity  + "' Where CONVERT (VARCHAR , ProductId)='" + cart.ProductId + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            AddToCart data = db.AddToCarts.Find(Id);
            return View(data);
        }
        public ActionResult DeleteCart(int Id)
        {
            AddToCart data = db.AddToCarts.Find(Id);
            db.AddToCarts.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}