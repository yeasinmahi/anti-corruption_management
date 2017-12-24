using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employee = _db.Employee.Include(e => e.Sajekas).Include(e => e.Wings);
            return View(employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name");
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,Designation,Address,EmployeeId,IsActive,WingId,SajekaId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", employee.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", employee.WingId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", employee.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", employee.WingId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,Designation,Address,EmployeeId,IsActive,WingId,SajekaId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SajekaId = new SelectList(_db.Sajeka, "Sl", "Name", employee.SajekaId);
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", employee.WingId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _db.Employee.Find(id);
            _db.Employee.Remove(employee);
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
