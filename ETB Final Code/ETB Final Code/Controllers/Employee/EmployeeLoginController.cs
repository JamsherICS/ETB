﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETB_Final_Code.Controllers.Employee
{
    public class EmployeeLoginController : Controller
    {
        // GET: EmployeeLogin
        private readonly Emp_travel_booking_systemEntities db; // Replace YourDbContext with your actual DbContext class

        public EmployeeLoginController()
        {
            db = new Emp_travel_booking_systemEntities(); // Initialize your DbContext
        }

        // GET: EmployeeLogin
        [HttpGet]
        public ActionResult ELogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ELogin(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Email and password are required.");
                }

                // Retrieve the admin by email
                var employee = db.employees.FirstOrDefault(a => a.email == email);

                // Validate admin existence and password
                if (employee != null && VerifyPassword(password, employee.emp_password))
                {
                    Session["EmployeeId"] = employee.employeeid;
                    // Redirect to the dashboard controller
                    return RedirectToAction("Index", "travelrequests");
                }
                else
                {
                    throw new Exception("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Compare entered password with hashed password
            return enteredPassword == hashedPassword;
        }
    }
}