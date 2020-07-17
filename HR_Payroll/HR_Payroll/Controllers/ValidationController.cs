using HR_Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Payroll.Controllers
{
    public class ValidationController : Controller
    {
        HR_PayrollEntities _db = new HR_PayrollEntities();
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UsernameExists(string username)
        {
            return Json(!String.Equals(username, "kiran", StringComparison.OrdinalIgnoreCase));
        }

        public JsonResult EmailExists(string email)
        {
            return Json(!String.Equals(email, "kiran@yahoo.com", StringComparison.OrdinalIgnoreCase));
        }
        public JsonResult IsCateCodeExists(string Category_Code)
        {
            //check if any of the Category code matches the CategoryCode specified in the Parameter using the ANY extension method
            return Json(!_db.Asset_Category.Any(x => x.Category_Code == Category_Code), JsonRequestBehavior.AllowGet);
        }
    }
}