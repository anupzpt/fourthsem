using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers.User
{
    public class OrderedController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TKCK2P7\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Resturantsystem");

        ResturantsystemEntities db;
        public OrderedController()
        {
            db = new ResturantsystemEntities();
        }
        public OrderModel orderModels = new OrderModel();
        // GET: Ordered
        public OrderModel FetchData(string UserId)
        {
            con.Open();
            string query = "SELECT A.Id,A.ProductId,A.UserId,A.ProductName,A.ProductPrice,A.Quantity,D.OfferPercent,P.ProductImage FROM AddToCart AS A  INNER JOIN DiscountTable AS D ON D.ProductId = A.ProductId INNER JOIN dbo.ProductTable AS P ON P.Id=A.ProductId Where CONVERT(VARCHAR,UserId)='" + UserId + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            orderModels.UserId = dt.Rows[0]["UserId"].ToString();
            orderModels.ProductId = dt.Rows[0]["ProductId"].ToString();
            orderModels.ProductName = dt.Rows[0]["ProductName"].ToString();
            orderModels.ProductPrice = dt.Rows[0]["ProductPrice"].ToString();
            orderModels.Quantity = dt.Rows[0]["Quantity"].ToString();
            orderModels.image = dt.Rows[0]["ProductImage"].ToString();
            orderModels.discount = dt.Rows[0]["OfferPercent"].ToString();
            con.Close();
            return orderModels;
        }
        public ActionResult Index(string UserId)
        {
            ViewBag.UserId = UserId;
            return View(FetchData(UserId));
        }
        [HttpPost]
        public ActionResult Order(Order order)
        {
            con.Open();
            order.Status = "P";
            string query = "INSERT INTO Orders(UserId,ProductId,Address,PaymentOption,Status,Date)VALUES('" + order.UserId + "','" + order.ProductId + "','" + order.Address + "','" + order.PaymentOption + "','" + order.Status + "','" + DateTime.Now + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("OrderComplete");

        }
        public ActionResult OrderComplete(Order order)
        {
            return View(FetchData(ViewBag.UserId));
        }
    }
}