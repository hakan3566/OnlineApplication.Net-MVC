using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace OnlineApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index(int page=1)
        {
            var values = context.Categories.ToList().ToPagedList(page,5);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCategory(int id)
        {
            var ctgry = context.Categories.Find(id);
            context.Categories.Remove(ctgry);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FetchCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View("FetchCategory", category);
        }

        public ActionResult CategoryUpdate(Category c)
        {
            var ctgry = context.Categories.Find(c.CategoryId);
            ctgry.CategoryName = c.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}