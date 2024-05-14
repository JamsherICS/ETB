using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETB_Today;
using System.Threading.Tasks;

namespace ETB_Today.Controllers.Admin
{
    public class employeesController : Controller
    {
        private Emp_travel_booking_systemEntities db = new Emp_travel_booking_systemEntities();

        // GET: employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.manager);
            return View(employees.ToList());
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            ViewBag.managerid = new SelectList(db.managers, "managerid", "name");
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeid,emp_name,email,emp_password,department,position,hiredate,phonenumber,address,managerid,status")] employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.status = true;
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managerid = new SelectList(db.managers, "managerid", "name", employee.managerid);
            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerid = new SelectList(db.managers, "managerid", "name", employee.managerid);
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeid,emp_name,email,emp_password,department,position,hiredate,phonenumber,address,managerid,status")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerid = new SelectList(db.managers, "managerid", "name", employee.managerid);
            return View(employee);
        }


        public class Employee
        {
            // Your existing properties
            public int EmployeeId { get; set; }
            public string Emp_Name { get; set; }
            public string Email { get; set; }
            // Add status property
            public bool Status { get; set; }
            // Other properties
        }


        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee != null)
            {
                if (employee.status == true)
                {
                    // Instead of removing, update the status to indicate soft delete

                    employee.status = false; // Assuming false indicates deleted
                     db.SaveChanges();
                }
                else
                {
                    employee.status = true; // Assuming false indicates deleted
                     db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }


        // GET: Employees/AssignManager/5
        public async Task<ActionResult> ChangeManager(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            employee employee =  db.employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.ManagerId = new SelectList(db.managers, "managerid", "name");
            return View(employee);
        }

        // POST: Employees/AssignManager/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeManager(int id, int managerId)
        {
            employee employee = db.employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            employee.managerid = managerId;
             db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
