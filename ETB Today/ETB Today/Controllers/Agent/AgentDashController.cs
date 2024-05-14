using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETB_Today;

namespace ETB_Today.Controllers.Agent
{
    public class AgentDashController : Controller
    {
        private readonly Emp_travel_booking_systemEntities db;

        public AgentDashController()
        {
            db = new Emp_travel_booking_systemEntities();
        }


        // GET: AgentDash
        public ActionResult AgentIndex()
        {
            if (!IsUserLoggedIn())
            {
                // If not logged in, redirect to the login page
                return RedirectToAction("AgentLogin");
            }

            // Retrieve pending travel requests and pass them to the view
            var pendingRequests = db.travelrequests;
            return View(pendingRequests);
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int requestId, string status)
        {
            try
            {
                // Check if the user is logged in
                if (!IsUserLoggedIn())
                {
                    // If not logged in, redirect to the login page
                    return RedirectToAction("AgentLogin");
                }

                // Retrieve the travel request by ID
                var travelRequest = db.travelrequests.FirstOrDefault(tr => tr.requestid == requestId);

                if (travelRequest == null)
                {
                    throw new Exception("Travel request not found.");
                }

                // Update the booking status based on availability
                travelRequest.bookingstatus = status;

                db.SaveChanges();

                TempData["SuccessMessage"] = "Booking status updated successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("AgentIndex");
        }


        private bool IsUserLoggedIn()
        {
            // Check if the user is logged in (e.g., check for authentication cookie or session variable)
            // Return true if logged in, false otherwise
            return Session["TravelAgentId"] != null;
        }

        // Example method for validating login credentials (replace with your actual logic)
       
    }
}