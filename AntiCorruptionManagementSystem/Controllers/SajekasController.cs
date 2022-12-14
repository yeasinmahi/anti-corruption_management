using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class SajekasController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: Sajekas
        public ActionResult Index()
        {
            return View(_db.Sajeka.Include(i=> i.Wings).ToList());
        }

        // GET: Sajekas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sajeka sajeka = _db.Sajeka.Find(id);
            if (sajeka == null)
            {
                return HttpNotFound();
            }
            return View(sajeka);
        }

        // GET: Sajekas/Create
        public ActionResult Create()
        {
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name");
            return View();
        }

        // POST: Sajekas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,WingId,Name")] Sajeka sajeka)
        {
            if (ModelState.IsValid)
            {
                _db.Sajeka.Add(sajeka);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name",sajeka.WingId);
            return View(sajeka);
        }

        // GET: Sajekas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sajeka sajeka = _db.Sajeka.Find(id);
            if (sajeka == null)
            {
                return HttpNotFound();
            }
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", sajeka.WingId);
            return View(sajeka);
        }

        // POST: Sajekas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,WingId,Name")] Sajeka sajeka)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sajeka).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WingId = new SelectList(_db.Wing, "Sl", "Name", sajeka.WingId);
            return View(sajeka);
        }

        // GET: Sajekas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sajeka sajeka = _db.Sajeka.Find(id);
            if (sajeka == null)
            {
                return HttpNotFound();
            }
            return View(sajeka);
        }

        // POST: Sajekas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sajeka sajeka = _db.Sajeka.Find(id);
            _db.Sajeka.Remove(sajeka);
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
