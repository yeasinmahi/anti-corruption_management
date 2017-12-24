using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class CaseObjectionsController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: CaseObjections
        public ActionResult Index()
        {
            var caseObjection = _db.CaseObjection.Include(c => c.Employees).Include(c => c.Wings);
            return View(caseObjection.ToList());
        }

        // GET: CaseObjections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseObjection caseObjection = _db.CaseObjection.Find(id);
            if (caseObjection == null)
            {
                return HttpNotFound();
            }
            return View(caseObjection);
        }

        // GET: CaseObjections/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            return View();
        }

        // POST: CaseObjections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,ERNumber,Name,Designation,Address,DateofObjection,ObjectionDetails,InquiryMemorandumNumber,InquiryDate,IsActive,WingId,EmployeeId")] CaseObjection caseObjection)
        {
            if (caseObjection.ErNumber!="" )
            {
                caseObjection.IsActive = true;
                _db.CaseObjection.Add(caseObjection);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", caseObjection.EmployeeId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", caseObjection.WingId);
            return View(caseObjection);
        }

        // GET: CaseObjections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseObjection caseObjection = _db.CaseObjection.Find(id);
            if (caseObjection == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", caseObjection.EmployeeId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", caseObjection.WingId);
            return View(caseObjection);
        }

        // POST: CaseObjections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,ERNumber,Name,Designation,Address,DateofObjection,ObjectionDetails,InquiryMemorandumNumber,InquiryDate,IsActive,WingId,EmployeeId")] CaseObjection caseObjection)
        {
            if (caseObjection.ErNumber != "")
            {
                _db.Entry(caseObjection).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", caseObjection.EmployeeId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", caseObjection.WingId);
            return View(caseObjection);
        }

        // GET: CaseObjections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseObjection caseObjection = _db.CaseObjection.Find(id);
            if (caseObjection == null)
            {
                return HttpNotFound();
            }
            return View(caseObjection);
        }

        // POST: CaseObjections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseObjection caseObjection = _db.CaseObjection.Find(id);
            caseObjection.IsActive = false;
            _db.Entry(caseObjection).State = EntityState.Modified;
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
