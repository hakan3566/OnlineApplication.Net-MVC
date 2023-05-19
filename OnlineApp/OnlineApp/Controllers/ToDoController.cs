using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context context = new Context();
        public ActionResult Index()
        {
            var val1 = context.Currents.Count().ToString();
            ViewBag.v1 = val1;
            var val2 = context.Products.Count().ToString();
            ViewBag.v2 = val2;
            var val3 = context.Categories.Count().ToString();
            ViewBag.v3 = val3;
            var val4 = (from x in context.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.v4 = val4;

            var toDoes = context.toDos.ToList();

            return View(toDoes);
        }
    }
}