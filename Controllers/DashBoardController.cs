using NDProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDProject.Controllers
{
    public class DashBoardController : BaseController
    {
        private readonly UserDetailsDAL _dal = new UserDetailsDAL();
        // GET: DashBoard
        public ActionResult Index()
        {
            
                string email = Session["Email"].ToString();
                var user = _dal.GetUserByEmail(email);
                ViewBag.User = email;

                return View(user); // Pass user details to the Dashboard view
            

           

        }
        [HttpPost]
        public ActionResult Registration()
        {
            // Perform any required processing here (e.g., saving data, validation)

            // Redirect to the Submit page
            return RedirectToAction("Submit", "Registration");
        }

        // GET: Submit
        //public ActionResult Submit()
        //{
        //    // Logic for the Submit page (e.g., confirmation message, final steps)
        //    return View();
        //}
    }
}
