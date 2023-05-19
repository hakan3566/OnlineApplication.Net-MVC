using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> values1 = (from x in context.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName,
                                                Value = x.DepartmentId.ToString()
                                            }).ToList();
            ViewBag.val1 = values1;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchEmployee(int id)
        {
            List<SelectListItem> values1 = (from x in context.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName,
                                                Value = x.DepartmentId.ToString()
                                            }).ToList();
            ViewBag.val1 = values1;
            var employee = context.Employees.Find(id);
            return View("FetchEmployee",employee);
        }

        public ActionResult EmployeeUpdate(Employee employee)
        {
            var emp = context.Employees.Find(employee.EmployeeId);
            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeSurname = employee.EmployeeSurname;
            emp.EmployeeImage = employee.EmployeeImage;
            emp.DepartmentId = employee.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeList()
        {
            var query = context.Employees.ToList();
            return View(query);
        }
    }
}