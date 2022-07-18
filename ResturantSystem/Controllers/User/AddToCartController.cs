using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            List<AddToCart> cartList = new List<AddToCart>();
            ViewBag.UserId = Session["UserId"];
            var userId = Session["UserId"];
            con.Open();
            string query = "SELECT * FROM AddToCart";// Where CONVERT(VARCHAR,UserId)='" + userId+ "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AddToCart cart = new AddToCart();
                cart.Id =Convert.ToInt32( dt.Rows[i]["Id"]);
                cart.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                cart.ProductName = dt.Rows[i]["ProductName"].ToString();
                cart.ProductPrice = dt.Rows[i]["ProductPrice"].ToString();
                cart.Quantity = dt.Rows[i]["Quantity"].ToString();
                cartList.Add(cart);
            }
            return View(cartList);
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
        public ActionResult EditCart(AddToCart cart)
        {
           
            con.Open();
            string query = "Update AddToCart set Quantity='" + cart.Quantity  + "' Where CONVERT (VARCHAR , Id)='" + cart.Id + "'";
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
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from dbo.AddToCart where CONVERT(VARCHAR, Id)='" + Id + "'";
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}