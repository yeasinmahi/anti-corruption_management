using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class InvestigationWorkProgressesController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        public ActionResult InvestigationProgressReport()
        {
            List<InvestigationWorkProgress> progressList = new List<InvestigationWorkProgress>();
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            return View(progressList);
        }
        public ActionResult InvestigationProgressReportView(int? employeeId, int? wingId, int? sajekaId)
        {
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            ViewBag.WingName = _db.Wing.Where(i => i.Sl == wingId).Select(p => p.Name).FirstOrDefault();
            ViewBag.SajekaName = _db.Sajeka.Where(i => i.Sl == sajekaId).Select(p => p.Name).FirstOrDefault();
            ViewBag.EmployeeName = _db.Employee.Where(i => i.Sl == employeeId).Select(p => p.Name).FirstOrDefault();
            List<InvestigationWorkProgress> progressList = _db.InvestigationWorkProgress.Where(t => t.EmployeeId == employeeId).Where(t=> t.WingId==wingId).Where(t => t.SajekaId == sajekaId).Include(x => x.Sajekas).Include(x => x.Wings).Include(x => x.Employees).ToList();
            var progressDate = _db.InvestigationWorkProgress.Select(t => t.DateofInvestigateOrder).FirstOrDefault();
            var halfProgressDate = progressDate.AddDays(15);
            ViewBag.halfProgressDate = halfProgressDate;
            var fullProgressDate = progressDate.AddDays(30);
            ViewBag.fullProgressDate = fullProgressDate;
            var currentDate = DateTime.Now;
            ViewBag.halfmonthCount = Math.Floor((halfProgressDate - currentDate).TotalDays);
            ViewBag.fullmonthCount = Math.Floor((fullProgressDate- currentDate).TotalDays);
            ViewBag.Status = "SelectEmployee";
            return View("InvestigationProgressReport", progressList);
        }

        // GET: InvestigationWorkProgresses
        public ActionResult Index()
        {
            var investigationWorkProgress = _db.InvestigationWorkProgress.Include(i => i.Accusers).Include(i => i.Employees).Include(i => i.Sajekas).Include(i => i.Wings);
            return View(investigationWorkProgress.ToList());
        }



        // GET: InvestigationWorkProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationWorkProgress investigationWorkProgress = _db.InvestigationWorkProgress.Find(id);
            if (investigationWorkProgress == null)
            {
                return HttpNotFound();
            }
            return View(investigationWorkProgress);
        }

        // GET: InvestigationWorkProgresses/Create
        public ActionResult Create()
        {
            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            return View();
        }

        // POST: InvestigationWorkProgresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,FileNumber,DateofInvestigateOrder,ComplainDescription,CurrentStatus,Remarks,IsActive,AccuserId,WingId,SajekaId,EmployeeId")] InvestigationWorkProgress investigationWorkProgress)
        {
            if (investigationWorkProgress.FileNumber!="")
            {
                investigationWorkProgress.IsActive = true;
                _db.InvestigationWorkProgress.Add(investigationWorkProgress);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name", investigationWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", investigationWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", investigationWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", investigationWorkProgress.WingId);
            return View(investigationWorkProgress);
        }

        // GET: InvestigationWorkProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationWorkProgress investigationWorkProgress = _db.InvestigationWorkProgress.Find(id);
            if (investigationWorkProgress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name", investigationWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", investigationWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", investigationWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", investigationWorkProgress.WingId);
            return View(investigationWorkProgress);
        }

        // POST: InvestigationWorkProgresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,FileNumber,DateofInvestigateOrder,ComplainDescription,CurrentStatus,Remarks,IsActive,AccuserId,WingId,SajekaId,EmployeeId")] InvestigationWorkProgress investigationWorkProgress)
        {
            if (investigationWorkProgress.FileNumber != "")
            {
                _db.Entry(investigationWorkProgress).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccuserId = new SelectList(_db.Accuser, "Sl", "Name", investigationWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", investigationWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", investigationWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", investigationWorkProgress.WingId);
            return View(investigationWorkProgress);
        }

        // GET: InvestigationWorkProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationWorkProgress investigationWorkProgress = _db.InvestigationWorkProgress.Find(id);
            if (investigationWorkProgress == null)
            {
                return HttpNotFound();
            }
            return View(investigationWorkProgress);
        }

        // POST: InvestigationWorkProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestigationWorkProgress investigationWorkProgress = _db.InvestigationWorkProgress.Find(id);
            investigationWorkProgress.IsActive = false;
            _db.Entry(investigationWorkProgress).State = EntityState.Modified;
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
