using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETB_Today.Controllers.Admin
{
    public class ViewRequestController : Controller
    {
        private readonly Emp_travel_booking_systemEntities db;

        public ViewRequestController()
        {
            db = new Emp_travel_booking_systemEntities();
        }
        // GET: ViewRequest
        [HttpGet]
        public ActionResult GetViewRequest()
        {
            var travelRequests = db.travelrequests.ToList();
            return View(travelRequests);
        }
    }
}