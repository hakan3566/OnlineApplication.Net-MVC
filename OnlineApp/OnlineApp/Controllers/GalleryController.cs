using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;
namespace OnlineApp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context Context = new Context();
        public ActionResult Index()
        {
            var values = Context.Products.ToList();
            return View(values);
        }
    }
}