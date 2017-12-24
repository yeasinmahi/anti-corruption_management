using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class WingsController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: Wings
        public ActionResult Index()
        {
            return View(_db.Wing.ToList());
        }

        // GET: Wings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wing wing = _db.Wing.Find(id);
            if (wing == null)
            {
                return HttpNotFound();
            }
            return View(wing);
        }

        // GET: Wings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name")] Wing wing)
        {
            if (ModelState.IsValid)
            {
                _db.Wing.Add(wing);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wing);
        }

        // GET: Wings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wing wing = _db.Wing.Find(id);
            if (wing == null)
            {
                return HttpNotFound();
            }
            return View(wing);
        }

        // POST: Wings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name")] Wing wing)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(wing).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wing);
        }

        // GET: Wings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wing wing = _db.Wing.Find(id);
            if (wing == null)
            {
                return HttpNotFound();
            }
            return View(wing);
        }

        // POST: Wings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wing wing = _db.Wing.Find(id);
            _db.Wing.Remove(wing);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
