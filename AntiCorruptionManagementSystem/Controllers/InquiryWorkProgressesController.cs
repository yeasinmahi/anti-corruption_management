using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class InquiryWorkProgressesController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();


        public ActionResult InquiryProgressReport()
        {
            List<InquiryWorkProgress> progressList = new List<InquiryWorkProgress>();
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            return View(progressList);
        }

        public ActionResult InquiryProgressReportView(int? employeeId, int? wingId, int? sajekaId)
        {
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            ViewBag.WingName = _db.Wing.Where(i => i.Sl == wingId).Select(p => p.Name).FirstOrDefault();
            ViewBag.SajekaName = _db.Sajeka.Where(i => i.Sl == sajekaId).Select(p => p.Name).FirstOrDefault();
            ViewBag.EmployeeName = _db.Employee.Where(i => i.Sl == employeeId).Select(p => p.Name).FirstOrDefault();
            List<InquiryWorkProgress> progressList = _db.InquiryWorkProgress.Where(t => t.EmployeeId == employeeId).Where(t => t.WingId == wingId).Where(t => t.SajekaId == sajekaId).Include(x=> x.Sajekas).Include(x => x.Wings).Include(x => x.Employees).ToList();
            var progressDate = _db.InquiryWorkProgress.Select(t => t.DateofInquiryOrder).FirstOrDefault();
            var halfProgressDate = progressDate.AddDays(15);
            ViewBag.halfProgressDate = halfProgressDate;
            var fullProgressDate = progressDate.AddDays(30);
            ViewBag.fullProgressDate = fullProgressDate;
            var currentDate = DateTime.Now;
            ViewBag.halfmonthCount = Math.Floor((halfProgressDate - currentDate).TotalDays);
            ViewBag.fullmonthCount = Math.Floor((fullProgressDate - currentDate).TotalDays);
            ViewBag.Status = "SelectEmployee";
            return View("InquiryProgressReport", progressList);
        }

        // GET: InquiryWorkProgresses
        public ActionResult Index()
        {
            var inquiryWorkProgress = _db.InquiryWorkProgress.Include(i => i.Accusers).Include(i => i.Employees).Include(i => i.Sajekas).Include(i => i.Wings);
            return View(inquiryWorkProgress.ToList());
        }

        // GET: InquiryWorkProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryWorkProgress inquiryWorkProgress = _db.InquiryWorkProgress.Find(id);
            if (inquiryWorkProgress == null)
            {
                return HttpNotFound();
            }
            return View(inquiryWorkProgress);
        }

        // GET: InquiryWorkProgresses/Create
        public ActionResult Create()
        {
            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
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
                inquiryWorkProgress.IsActive = true;
                _db.InquiryWorkProgress.Add(inquiryWorkProgress);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name", inquiryWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", inquiryWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", inquiryWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", inquiryWorkProgress.WingId);
            return View(inquiryWorkProgress);
        }

        // GET: InquiryWorkProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryWorkProgress inquiryWorkProgress = _db.InquiryWorkProgress.Find(id);
            if (inquiryWorkProgress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name", inquiryWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", inquiryWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", inquiryWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", inquiryWorkProgress.WingId);
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
                _db.Entry(inquiryWorkProgress).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name", inquiryWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", inquiryWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", inquiryWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", inquiryWorkProgress.WingId);
            return View(inquiryWorkProgress);
        }

        // GET: InquiryWorkProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryWorkProgress inquiryWorkProgress = _db.InquiryWorkProgress.Find(id);
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
            InquiryWorkProgress inquiryWorkProgress = _db.InquiryWorkProgress.Find(id);
            if (inquiryWorkProgress != null)
            {
                inquiryWorkProgress.IsActive = false;
                _db.Entry(inquiryWorkProgress).State = EntityState.Modified;
            }
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
