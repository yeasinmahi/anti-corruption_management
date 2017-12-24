using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AntiCorruptionManagementSystem.Models;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class AccusersController : Controller
    {
        private AcmsDbContext _db = new AcmsDbContext();

        // GET: Accusers
        public ActionResult Index()
        {
            return View(_db.Accuser.ToList());
        }

        // GET: Accusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accuser accuser = _db.Accuser.Find(id);
            if (accuser == null)
            {
                return HttpNotFound();
            }
            return View(accuser);
        }

        // GET: Accusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl,Name,IsActive")] Accuser accuser)
        {
            if (accuser.Name!= "")
            {
                accuser.IsActive = true;
                _db.Accuser.Add(accuser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accuser);
        }

        // GET: Accusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accuser accuser = _db.Accuser.Find(id);
            if (accuser == null)
            {
                return HttpNotFound();
            }
            return View(accuser);
        }

        // POST: Accusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl,Name,IsActive")] Accuser accuser)
        {
            if (accuser.Name != "")
            {
                _db.Entry(accuser).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accuser);
        }

        // GET: Accusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accuser accuser = _db.Accuser.Find(id);
            if (accuser == null)
            {
                return HttpNotFound();
            }
            return View(accuser);
        }

        // POST: Accusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accuser accuser = _db.Accuser.Find(id);
            accuser.IsActive = false;
            _db.Entry(accuser).State = EntityState.Modified;
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
