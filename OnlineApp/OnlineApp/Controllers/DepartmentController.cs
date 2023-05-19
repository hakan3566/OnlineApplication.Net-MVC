using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Departments.Where(x=>x.Situation == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveDepartment(int id)
        {
            var department = context.Departments.Find(id);
            department.Situation = false;
            context.SaveChanges();            
            return RedirectToAction("Index");
        }

        public ActionResult FetchDepartment(int id)
        {
            var department = context.Departments.Find(id);
            return View("FetchDepartment", department);
        }

        public ActionResult DepartmentUpdate(Department department)
        {
            var dept = context.Departments.Find(department.DepartmentId);
            dept.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail (int id)
        {
            var values = context.Employees.Where(x => x.DepartmentId == id).ToList();
            var dpt = context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);
        }

        public ActionResult DepartmentEmployeeSales(int id)
        {
            var values = context.SalesTransactions.Where(x => x.EmployeeId == id).ToList();
            var em = context.Employees.Where(x => x.EmployeeId == id).Select(y => y.EmployeeName +" " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.de = em;
            return View(values);
        }

    }
}