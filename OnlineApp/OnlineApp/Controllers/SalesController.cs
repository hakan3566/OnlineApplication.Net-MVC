using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.SalesTransactions.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> value1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " +x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();

            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesTransaction salesTransaction)
        {
            salesTransaction.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(salesTransaction);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchSales(int id)
        {
            List<SelectListItem> value1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in context.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();

            ViewBag.val1 = value1;
            ViewBag.val2 = value2;
            ViewBag.val3 = value3;
            var value = context.SalesTransactions.Find(id);
            return View("FetchSales", value);
        }

        public ActionResult UpdateSales(SalesTransaction s)
        {
            var sales = context.SalesTransactions.Find(s.SalesId);
            sales.CurrentId = s.CurrentId;
            sales.Number = s.Number;
            sales.Price = s.Price;
            sales.EmployeeId = s.EmployeeId;
            sales.Date = s.Date;
            sales.AggregateAmount = s.AggregateAmount;
            sales.Productid = s.Productid;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SalesDetail(int id)
        {
            var values = context.SalesTransactions.Where(x => x.SalesId == id).ToList();
            return View(values);
        }
    }
}