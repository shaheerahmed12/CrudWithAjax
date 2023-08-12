using singlePage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Management;
using System.Web.UI.WebControls;
using singlePage.ViewModel;

namespace singlePage.Controllers
{
    public class EmpController : Controller
    {
        DbHandler empdb = new DbHandler();
        // GET: Emp
        
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get(Employee emp)
        {
            return Json(empdb.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DataEntry()
        {
            return PartialView();
        }

        public ActionResult DataUpdate()
        {
            return PartialView();
        }
        public JsonResult SaveChange(Employee emp)
        {

            return Json(empdb.Add(emp), JsonRequestBehavior.AllowGet);



        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empdb.ListAll().Find(x => x.Id.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            return Json(empdb.Update(emp), JsonRequestBehavior.AllowGet);
        }
    }
}