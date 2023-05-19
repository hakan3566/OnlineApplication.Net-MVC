using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context = new Context();
        public ActionResult Index()
        {
            Class1 class1 = new Class1();
            // var values = context.Products.Where(x => x.ProductId == 1).ToList();
            class1.Value1 = context.Products.Where(x => x.ProductId == 1).ToList();
            class1.Value2 = context.Details.Where(y => y.DetailId == 1).ToList();
            return View(class1);
        }
    }
}