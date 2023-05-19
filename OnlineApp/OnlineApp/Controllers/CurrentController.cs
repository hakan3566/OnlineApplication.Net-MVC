using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context context = new Context();

        public ActionResult Index()
        {
            var values = context.Currents.Where(x=>x.Situation==true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            current.Situation = true;
            context.Currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCurrent(int id)
        {
            var crnt = context.Currents.Find(id);
            crnt.Situation = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchCurrent(int id)
        {
            var current = context.Currents.Find(id);
            return View("FetchCurrent", current);
        }
        public ActionResult CurrentUpdate(Current c)
        {
            if (!ModelState.IsValid)
            {
                return View("FetchCurrent");
            }
            var current = context.Currents.Find(c.CurrentId);
            current.CurrentName = c.CurrentName;
            current.CurrentSurname = c.CurrentSurname;
            current.CurrentCity = c.CurrentCity;
            current.CurrentMail = c.CurrentMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CurrentSales(int id)
        {
            var values = context.SalesTransactions.Where(x => x.CurrentId == id).ToList();
            var cr = context.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.ce = cr;
            return View(values);
        }

    }
}