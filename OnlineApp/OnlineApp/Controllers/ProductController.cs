using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index()
        {
            var products = context.Products.Where(x=>x.Situation==true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values1 = (from x in context.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.val1 = values1;

            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveProduct(int id)
        {
            var product = context.Products.Find(id);
            product.Situation = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchProduct(int id)
        {
            List<SelectListItem> values1 = (from x in context.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.val1 = values1;
            var product = context.Products.Find(id);
            return View("FetchProduct", product);
        }

        public ActionResult UpdateProduct(Product p)
        {
            var product = context.Products.Find(p.ProductId);
            product.ProductName = p.ProductName;
            product.PurchasePrice = p.PurchasePrice;
            product.Situation = p.Situation;
            product.CategoryId = p.CategoryId;
            product.Brand = p.Brand;
            product.SalePrice = p.SalePrice;
            product.Stock = p.Stock;
            product.ProductImage = p.ProductImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }

    }
}