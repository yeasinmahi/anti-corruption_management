﻿using System;
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
    public class InvestigationWorkProgressesController : Controller
    {
        private ACMSDbContext db = new ACMSDbContext();

        // GET: InvestigationWorkProgresses
        public ActionResult Index()
        {
            var investigationWorkProgress = db.InvestigationWorkProgress.Include(i => i.Accusers).Include(i => i.Employees).Include(i => i.Sajekas).Include(i => i.Wings);
            return View(investigationWorkProgress.ToList());
        }

        // GET: InvestigationWorkProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationWorkProgress investigationWorkProgress = db.InvestigationWorkProgress.Find(id);
            if (investigationWorkProgress == null)
            {
                return HttpNotFound();
            }
            return View(investigationWorkProgress);
        }

        // GET: InvestigationWorkProgresses/Create
        public ActionResult Create()
        {
            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name");
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
                db.InvestigationWorkProgress.Add(investigationWorkProgress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name", investigationWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", investigationWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", investigationWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", investigationWorkProgress.WingId);
            return View(investigationWorkProgress);
        }

        // GET: InvestigationWorkProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationWorkProgress investigationWorkProgress = db.InvestigationWorkProgress.Find(id);
            if (investigationWorkProgress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name", investigationWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", investigationWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", investigationWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", investigationWorkProgress.WingId);
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
                db.Entry(investigationWorkProgress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccuserId = new SelectList(db.Accuser, "Sl", "Name", investigationWorkProgress.AccuserId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "Sl", "Name", investigationWorkProgress.EmployeeId);
            ViewBag.SajekaId = new SelectList(db.Sajeka, "Sl", "Name", investigationWorkProgress.SajekaId);
            ViewBag.WingId = new SelectList(db.Wing, "Sl", "Name", investigationWorkProgress.WingId);
            return View(investigationWorkProgress);
        }

        // GET: InvestigationWorkProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationWorkProgress investigationWorkProgress = db.InvestigationWorkProgress.Find(id);
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
            InvestigationWorkProgress investigationWorkProgress = db.InvestigationWorkProgress.Find(id);
            db.InvestigationWorkProgress.Remove(investigationWorkProgress);
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