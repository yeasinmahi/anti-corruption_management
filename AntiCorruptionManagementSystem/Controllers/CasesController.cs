using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class CasesController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: Cases
        public ActionResult Index()
        {
            var caseList = _db.Case.Include(e => e.Employees).Include(e => e.Sajekas).Include(e => e.Wings);
            return View(caseList.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = _db.Case.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            return View(cases);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name");
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
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
                _db.Case.Add(cases);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", cases.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", cases.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", cases.WingId);
            return View(cases);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = _db.Case.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", cases.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", cases.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", cases.WingId);
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
                _db.Entry(cases).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(_db.Employee, "Sl", "Name", cases.EmployeeId);
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", cases.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", cases.WingId);
            return View(cases);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = _db.Case.Find(id);
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
            Case cases = _db.Case.Find(id);
            cases.IsActive = false;
            _db.Entry(cases).State = EntityState.Modified;
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
