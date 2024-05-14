using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETB_Today.Controllers.Employee
{
    public class EmployeeHomeController : Controller
    {
        // GET: EmployeeHome
        public ActionResult EHome()
        {
            return View();
        }
    }
}