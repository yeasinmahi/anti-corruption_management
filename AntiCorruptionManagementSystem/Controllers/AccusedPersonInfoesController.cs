using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class AccusedPersonInfoesController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: AccusedPersonInfoes
        public ActionResult Index()
        {
            var accusedPersonInfo = _db.AccusedPersonInfo.Include(a => a.Cases).Include(a => a.Employees);
            return View(accusedPersonInfo.ToList());
        }

        // GET: AccusedPersonInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccusedPersonInfo accusedPersonInfo = _db.AccusedPersonInfo.Find(id);
            if (accusedPersonInfo == null)
            {
                return HttpNotFound();
            }
            return View(accusedPersonInfo);
        }

        // GET: AccusedPersonInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CaseId = new SelectList(_db.Case, "Sl", "CaseNumber");
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            return View();
        }

        // POST: AccusedPersonInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,Designation,Address,DateofCaseSubmission,CaseShortDescription,IsActive,CaseId,EmployeeId")] AccusedPersonInfo accusedPersonInfo)
        {
            if (accusedPersonInfo.Name!= "")
            {
                _db.AccusedPersonInfo.Add(accusedPersonInfo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseId = new SelectList(_db.Case, "Sl", "CaseNumber", accusedPersonInfo.CaseId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", accusedPersonInfo.EmployeeId);
            return View(accusedPersonInfo);
        }

        // GET: AccusedPersonInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccusedPersonInfo accusedPersonInfo = _db.AccusedPersonInfo.Find(id);
            if (accusedPersonInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseId = new SelectList(_db.Case, "Sl", "CaseNumber", accusedPersonInfo.CaseId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", accusedPersonInfo.EmployeeId);
            return View(accusedPersonInfo);
        }

        // POST: AccusedPersonInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,Designation,Address,DateofCaseSubmission,CaseShortDescription,IsActive,CaseId,EmployeeId")] AccusedPersonInfo accusedPersonInfo)
        {
            if (accusedPersonInfo.Name != "")
            {
                _db.Entry(accusedPersonInfo).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseId = new SelectList(_db.Case, "Sl", "CaseNumber", accusedPersonInfo.CaseId);
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", accusedPersonInfo.EmployeeId);
            return View(accusedPersonInfo);
        }

        // GET: AccusedPersonInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccusedPersonInfo accusedPersonInfo = _db.AccusedPersonInfo.Find(id);
            if (accusedPersonInfo == null)
            {
                return HttpNotFound();
            }
            return View(accusedPersonInfo);
        }

        // POST: AccusedPersonInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccusedPersonInfo accusedPersonInfo = _db.AccusedPersonInfo.Find(id);
            accusedPersonInfo.IsActive = false;
            _db.Entry(accusedPersonInfo).State = EntityState.Modified;
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
