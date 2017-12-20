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
    public class InquiryWorkProgressesController : Controller
    {
        private ACMSDbContext db = new ACMSDbContext();

        // GET: InquiryWorkProgresses
        public ActionResult Index()
        {
            var inquiryWorkProgress = db.InquiryWorkProgress.Include(i => i.Accusers).Include(i => i.Employees).Include(i => i.Sajekas).Include(i => i.Wings);
            return View(inquiryWorkProgress.ToList());
        }

        // GET: InquiryWorkProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryWorkProgress inquiryWorkProgress = db.InquiryWorkProgress.Find(id);
            if (inquiryWorkProgress == null)
            {
                return HttpNotFound();
            }
            return View(inquiryWorkProgress);
        }

        // GET: InquiryWorkProgresses/Create
        public ActionResult Create()
        {
            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name");
            return View();
        }

        // POST: InquiryWorkProgresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,FileNumber,DateofInquiryOrder,ComplainDescription,CurrentStatus,Remarks,IsActive,AccuserId,WingId,SajekaId,EmployeeId")] InquiryWorkProgress inquiryWorkProgress)
        {
            if (inquiryWorkProgress.FileNumber!="")
            {
                db.InquiryWorkProgress.Add(inquiryWorkProgress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name", inquiryWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", inquiryWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", inquiryWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", inquiryWorkProgress.WingId);
            return View(inquiryWorkProgress);
        }

        // GET: InquiryWorkProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryWorkProgress inquiryWorkProgress = db.InquiryWorkProgress.Find(id);
            if (inquiryWorkProgress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name", inquiryWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", inquiryWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", inquiryWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", inquiryWorkProgress.WingId);
            return View(inquiryWorkProgress);
        }

        // POST: InquiryWorkProgresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,FileNumber,DateofInquiryOrder,ComplainDescription,CurrentStatus,Remarks,IsActive,AccuserId,WingId,SajekaId,EmployeeId")] InquiryWorkProgress inquiryWorkProgress)
        {
            if (inquiryWorkProgress.FileNumber != "")
            {
                db.Entry(inquiryWorkProgress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name", inquiryWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", inquiryWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", inquiryWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", inquiryWorkProgress.WingId);
            return View(inquiryWorkProgress);
        }

        // GET: InquiryWorkProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryWorkProgress inquiryWorkProgress = db.InquiryWorkProgress.Find(id);
            if (inquiryWorkProgress == null)
            {
                return HttpNotFound();
            }
            return View(inquiryWorkProgress);
        }

        // POST: InquiryWorkProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InquiryWorkProgress inquiryWorkProgress = db.InquiryWorkProgress.Find(id);
            db.InquiryWorkProgress.Remove(inquiryWorkProgress);
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
