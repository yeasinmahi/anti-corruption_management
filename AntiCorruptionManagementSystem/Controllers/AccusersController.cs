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
    public class AccusersController : Controller
    {
        private ACMSDbContext db = new ACMSDbContext();

        // GET: Accusers
        public ActionResult Index()
        {
            return View(db.Accuser.ToList());
        }

        // GET: Accusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accuser accuser = db.Accuser.Find(id);
            if (accuser == null)
            {
                return HttpNotFound();
            }
            return View(accuser);
        }

        // GET: Accusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,IsActive")] Accuser accuser)
        {
            if (accuser.Name!= "")
            {
                db.Accuser.Add(accuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accuser);
        }

        // GET: Accusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accuser accuser = db.Accuser.Find(id);
            if (accuser == null)
            {
                return HttpNotFound();
            }
            return View(accuser);
        }

        // POST: Accusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,IsActive")] Accuser accuser)
        {
            if (accuser.Name != "")
            {
                db.Entry(accuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accuser);
        }

        // GET: Accusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accuser accuser = db.Accuser.Find(id);
            if (accuser == null)
            {
                return HttpNotFound();
            }
            return View(accuser);
        }

        // POST: Accusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accuser accuser = db.Accuser.Find(id);
            db.Accuser.Remove(accuser);
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
