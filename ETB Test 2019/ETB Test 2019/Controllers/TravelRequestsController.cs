using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETB_Test_2019;

namespace ETB_Test_2019.Controllers
{
    public class TravelRequestsController : Controller
    {
        private finalDBEntities db = new finalDBEntities();

        // GET: TravelRequests
        public ActionResult Index()
        {
            var travelRequests = db.TravelRequests.Include(t => t.User);
            return View(travelRequests.ToList());
        }

        // GET: TravelRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelRequest travelRequest = db.TravelRequests.Find(id);
            if (travelRequest == null)
            {
                return HttpNotFound();
            }
            return View(travelRequest);
        }

        // GET: TravelRequests/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserId");
            return View();
        }

        // POST: TravelRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,RequestDate,FromLocation,ToLocation,UserId")] TravelRequest travelRequest)
        {
            if (ModelState.IsValid)
            {
                db.TravelRequests.Add(travelRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "LoginId", travelRequest.UserId);
            return View(travelRequest);
        }

        // GET: TravelRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelRequest travelRequest = db.TravelRequests.Find(id);
            if (travelRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "LoginId", travelRequest.UserId);
            return View(travelRequest);
        }

        // POST: TravelRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,RequestDate,FromLocation,ToLocation,UserId,CurrentStatus")] TravelRequest travelRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "LoginId", travelRequest.UserId);
            return View(travelRequest);
        }

        // GET: TravelRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelRequest travelRequest = db.TravelRequests.Find(id);
            if (travelRequest == null)
            {
                return HttpNotFound();
            }
            return View(travelRequest);
        }

        // POST: TravelRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TravelRequest travelRequest = db.TravelRequests.Find(id);
            db.TravelRequests.Remove(travelRequest);
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
