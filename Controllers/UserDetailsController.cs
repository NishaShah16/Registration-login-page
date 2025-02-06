using NDProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDProject.Controllers
{
    public class UserDetailsController : Controller
    {
        public UserDetailsDAL _dal = new UserDetailsDAL(); // Data Access Layer

        // GET: UserDetails/Create
        [HttpGet]
        public ActionResult Create()
        {
            // Fetch dropdown values
            var programmes = _dal.GetDropdownValues();

            // Ensure programmes is not null
            if (programmes == null)
            {
                programmes = new List<DropdownList>(); // Initialize with an empty list
            }

            // Pass the list to ViewBag
            ViewBag.Programmes = programmes;
            return View();
        }

        // POST: UserDetails/Create
        [HttpPost]
        public ActionResult Create(UserDetails user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Save user details to the database
                    _dal.AddUser(user);
                    TempData["Message"] = "User details saved successfully!";
                    return RedirectToAction("Create");
                }

                // Reload dropdown values for the form in case of errors
                ViewBag.Programmes = _dal.GetDropdownValues();

                return View(user);
            }
            catch
            {
                TempData["Error"] = "An error occurred while saving user details.";
                return View(user);
            }
        }
    }
}