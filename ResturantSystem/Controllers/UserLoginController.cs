using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResturantSystem.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace ResturantSystem.Controllers
{
    public class UserLoginController : Controller
    {
        
        // GET: /UserLogin/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Enroll e)
        {

            String SqlCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string SqlQuery = "select UserName,Password from Enrollment where UserName=@UserName and Password=@Password";
            string status;
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery,con);;
            cmd.Parameters.AddWithValue("@UserName", e.UserName);
            cmd.Parameters.AddWithValue("@Password", e.Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["UserName"] = e.UserName.ToString();
                if (e.UserName == "admin" && e.Password == "admin")
                {
                    return this.RedirectToAction("Welcome");
                }
                else
                {
                    Session["UserName"] = e.UserName.ToString();
                    return this.RedirectToAction("Index", "Home");
                } }
            else
            {
                ViewData["Message"] = "User Login Details Failed!!";
            }
            
            if (e.UserName.ToString() != null)
            {
                Session["UserName"] = e.UserName.ToString();
                status = "1";
            }
            else
            {
                status = "3";
            }
            con.Close();
            return View();
            return new JsonResult { Data = new { status = status } };
        }
       
        [HttpGet]
        public ActionResult Welcome()
        {
            Enroll user = new Enroll();
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-K82V98C\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Resturantsystem"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Enrollment", con))
                {
                    //cmd.Parameters.AddWithValue("@status", "Get");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    List<Enroll> userlist = new List<Enroll>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Enroll uobj = new Enroll();
                        uobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                        uobj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                        uobj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                        uobj.UserName = ds.Tables[0].Rows[i]["UserName"].ToString();
                        uobj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                        uobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                        uobj.PhoneNumber = ds.Tables[0].Rows[i]["Phone"].ToString();
                        uobj.SecurityAnwser = ds.Tables[0].Rows[i]["SecurityAnswer"].ToString();
                        uobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();

                        userlist.Add(uobj);

                    }
                    user.Enrollsinfo = userlist;
                }
                con.Close();

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "UserLogin");
        }
    }
}
