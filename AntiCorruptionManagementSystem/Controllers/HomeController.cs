using AntiCorruptionManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AntiCorruptionManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public AcmsDbContext _db = null;
        public UserManager<ApplicationUser> UserManager = null;

        public HomeController()
        {
            this._db = new AcmsDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AcmsDbContext()));
        }

        public ActionResult Index()
        {
            ViewBag.TotalWing = _db.Wing.Count();
            ViewBag.TotalSajeka = _db.Sajeka.Count();
            ViewBag.Cases = _db.Case.Count();
            ViewBag.CasesObjection = _db.CaseObjection.Count();

            ViewBag.TotalEmployee = _db.Employee.Count();
            ViewBag.TotalAccuser = _db.Accuser.Count();
            ViewBag.TotalAccused = _db.AccusedPersonInfo.Count();
            ViewBag.Time = DateTime.Now;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}