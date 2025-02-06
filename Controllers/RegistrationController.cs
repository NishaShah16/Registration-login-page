using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using NDProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDProject.Controllers
{
    public class RegistrationController : BaseController
    {
        public  UserDetailsDAL _register = new UserDetailsDAL();

        // GET: Registration
        [HttpGet]
        public ActionResult Submit()
        {

            try
            {
                var categories = _register.GetCategoryValues() ?? new List<Category>();
                var subcategories = _register.GetSubcategoryValues() ?? new List<Subcategory>();
                var colleges = _register.GetCollegeNameValues() ?? new List<CollegeName>();

                ViewBag.Category = categories;
                ViewBag.Subcategory = subcategories;
                ViewBag.CollegeName = colleges;

                return View( new Registration());
            }
            catch (Exception)
            {
                // Log the exception (optional)
                // Log.Error("Error fetching dropdown values: " + ex.Message);

                TempData["ErrorMessage"] = "An error occurred while loading the form.";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult Submit(Registration registration)
        {
            var email = Session["Email"]?.ToString();

            // Check if the email is available in session
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Login");
            }
            try
            {
                // Reload dropdown values in case of validation failure
                ViewBag.Category = _register.GetCategoryValues() ?? new List<Category>();
                ViewBag.Subcategory = _register.GetSubcategoryValues() ?? new List<Subcategory>();
                ViewBag.CollegeName = _register.GetCollegeNameValues() ?? new List<CollegeName>();

                if (ModelState.IsValid)
                {
                    // Handle file upload and convert to byte array
                    byte[] photoBytes = null;
                    if (registration.NOCFilePath != null && registration.NOCFilePath.ContentLength > 0)
                    {
                        
                        using (Stream fs = registration.NOCFilePath.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            photoBytes = br.ReadBytes((int)fs.Length);
                        }
                        string photoPath = Server.MapPath("~/Photos");
                        if (!Directory.Exists(photoPath))
                        {
                            Directory.CreateDirectory(photoPath);
                        }

                        string photoFileName = Path.GetFileName(registration.NOCFilePath.FileName);
                        string fullPhotoPath = Path.Combine(photoPath, photoFileName);
                        registration.NOCFilePath.SaveAs(fullPhotoPath);
                    }


                    

                    // Save registration details to the database
                    _register.SubmitRegistrationForm(registration, photoBytes);

                    TempData["SuccessMessage"] = "Form submitted successfully!";
                    return View(registration);
                }

                // Return to the same view with validation errors
                return View(registration);
            }
            catch (Exception)
            {
                // Log the exception (optional)
                // Log.Error("Error submitting registration form: " + ex.Message);

                TempData["ErrorMessage"] = "An error occurred while saving your details. Please try again.";
                return View(registration);
            }
        }
        [HttpGet]
        public ActionResult RegistrationSuccess()
        {
            return View();
        }
    }
}
