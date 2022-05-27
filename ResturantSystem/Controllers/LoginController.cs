using ResturantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantSystem.Controllers
{
    public class LoginController : Controller
    {
        ResturantsystemEntities db = new ResturantsystemEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            login login = db.login.FirstorDefault(x => x.username == username && x.password == password)
            if(login == null)
            {
                ViewBag.ErrorMsg = "Username Or Password is Incorrect";
                return View();
            }
            SystemInfoForSession systemSession = new SystemInfoForSession();
            systemSession.Userid = login.userid;
            systemSession.Username = login.username;
            Session["SystemInfoForSession"] = systemSession;
            return RedirectToAction("Index", "Admin");
        }
    }
}