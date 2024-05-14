using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETB_Today.Controllers.Agent
{
    public class AgentLoginController : Controller
    {
        private readonly Emp_travel_booking_systemEntities db; // Replace YourDbContext with your actual DbContext class

        public AgentLoginController()
        {
            db = new Emp_travel_booking_systemEntities(); // Initialize your DbContext
        }

        // GET: EmployeeLogin
        [HttpGet]
        public ActionResult AgentLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgentLogin(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Email and password are required.");
                }

                // Retrieve the admin by email
                var agent = db.travelagents.FirstOrDefault(a => a.email == email);

                // Validate admin existence and password
                if (agent != null && VerifyPassword(password, agent.travel_agent_password) && agent.status == true)
                {
                    Session["TravelAgentId"] = 1; // Replace with actual ID
                     // Use the provided username

                    // Redirect to the dashboard controller
                    return RedirectToAction("AgentIndex", "AgentDash");
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