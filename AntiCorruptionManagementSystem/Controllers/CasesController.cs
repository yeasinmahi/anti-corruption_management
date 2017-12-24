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
    public class CasesController : Controller
    {
        private AcmsDbContext db = new AcmsDbContext();

        // GET: Cases
        public ActionResult Index()
        {
            var caseList = db.Case.Include(e => e.Employees).Include(e => e.Sajekas).Include(e => e.Wings);
            return View(caseList.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = db.Case.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            return View(cases);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,CaseNumber,CaseDate,Description,DateofIOTaken,ProgressDetails,Remarks,IsActive,WingId,SajekaId,EmployeeId")] Case cases)
        {
            if (cases.CaseNumber!="")
            {
                cases.IsActive = true;
                db.Case.Add(cases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", cases.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", cases.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", cases.WingId);
            return View(cases);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = db.Case.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", cases.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", cases.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", cases.WingId);
            return View(cases);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,CaseNumber,CaseDate,Description,DateofIOTaken,ProgressDetails,Remarks,IsActive,WingId,SajekaId,EmployeeId")] Case cases)
        {
            if (cases.CaseNumber != "")
            {
                db.Entry(cases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", cases.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", cases.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", cases.WingId);
            return View(cases);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = db.Case.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            return View(cases);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case cases = db.Case.Find(id);
            cases.IsActive = false;
            db.Entry(cases).State = EntityState.Modified;
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
