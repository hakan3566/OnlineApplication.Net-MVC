using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Istatistics
        Context Context = new Context();
        public ActionResult Index()
        {
            var value1 = Context.Currents.Count().ToString();
            ViewBag.d1 = value1;

            var value2 = Context.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = Context.Employees.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = Context.Categories.Count().ToString();
            ViewBag.d4 = value4;

            var value5 = Context.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = value5;

            var value6 = (from x in Context.Products where x.Brand != null  select x.Brand ).Distinct().Count().ToString();
            ViewBag.d6 = value6;

            var value7 = Context.Products.Count(x => x.Stock<=20).ToString();
            ViewBag.d7 = value7;

            var value8 = (from x in Context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;

            var value9 = (from x in Context.Products  orderby x.SalePrice ascending where x.SalePrice != 0  select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;

            var value10 = Context.Products.Count(x => x.ProductName == "Freezer").ToString();
            ViewBag.d10 = value10;

            var value11 = Context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = value11;

            var value12 = Context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = value12;

            var value13 = Context.Products.Where(u=>u.ProductId == 
            ( Context.SalesTransactions.GroupBy(x => x.Productid).OrderByDescending(z => z.Count())
            .Select(y => y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;

            var value14 = Context.SalesTransactions.Sum(x => x.AggregateAmount).ToString();
            ViewBag.d14 = value14;

            DateTime today = DateTime.Today;
            var value15 = Context.SalesTransactions.Count(x => x.Date == today).ToString();
            ViewBag.d15 = value15;

           // var value16 = Context.SalesTransactions.Where(x => x.Date == today).Sum(y => y.AggregateAmount).ToString();
            //ViewBag.d16 = value16;


            return View();
        }

        public ActionResult SimpleTables()
        {
            var query = (from x in Context.Currents
                         group x by x.CurrentCity into g
                         select new ClassGroup
                         {
                             City = g.Key,
                             Number = g.Count()
                         });
            return View(query.ToList());
        } 

        public PartialViewResult Partial1()
        {
            var query2 = (from x in Context.Employees
                          group x by x.Department.DepartmentName into g
                          select new ClassGroup2
                          {
                              Department = g.Key,
                              Number = g.Count()
                          });
            return PartialView(query2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query3 = Context.Currents.ToList();
            return PartialView(query3);
        }

        public PartialViewResult Partial3()
        {
            var query = Context.Products.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial4()
        {
            var query4 = (from x in Context.Products
                          group x by x.Brand into g
                          select new ClassGroup3
                          {
                              Brand = g.Key,
                              Number = g.Count()
                          });
            return PartialView(query4.ToList());
        }
    }
}