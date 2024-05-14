using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETB_Today;

namespace ETB_Today.Controllers.Admin
{
    public class travelagentsController : Controller
    {
        private Emp_travel_booking_systemEntities db = new Emp_travel_booking_systemEntities();

        // GET: travelagents
        public ActionResult Index()
        {
            return View(db.travelagents.ToList());
        }

        // GET: travelagents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travelagent travelagent = db.travelagents.Find(id);
            if (travelagent == null)
            {
                return HttpNotFound();
            }
            return View(travelagent);
        }

        // GET: travelagents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: travelagents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "agentid,name,email,travel_agent_password,status")] travelagent travelagent)
        {
            if (ModelState.IsValid)
            {
                db.travelagents.Add(travelagent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travelagent);
        }

        // GET: travelagents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travelagent travelagent = db.travelagents.Find(id);
            if (travelagent == null)
            {
                return HttpNotFound();
            }
            return View(travelagent);
        }

        // POST: travelagents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "agentid,name,email,travel_agent_password,status")] travelagent travelagent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelagent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travelagent);
        }

        // GET: travelagents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            travelagent travelagent = db.travelagents.Find(id);
            if (travelagent == null)
            {
                return HttpNotFound();
            }
            return View(travelagent);
        }

        // POST: travelagents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            travelagent travelagent = db.travelagents.Find(id);
            db.travelagents.Remove(travelagent);
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
