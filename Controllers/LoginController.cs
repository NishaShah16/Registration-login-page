using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using NDProject.Models;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using System.Web;

namespace NDProject.Controllers
{
    public class LoginController : Controller
    {
         public UserDetailsDAL _userDetailsDAL = new UserDetailsDAL();

    // Constructor to initialize Data Access Layer
    //public LoginController()
    //{
    //    _userDetailsDAL = new UserDetailsDAL();
    //}

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and Password are required.";
                return View();
            }

           // Authenticate using Data Access Layer




            if (_userDetailsDAL.ValidateUser(email, password))
            {
                // Set session
                Session["Email"] = email;
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }
        }

        // Logout Action
        public ActionResult Logout()
        {
            // Clear session
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Login","Login");
        }
    }
}

