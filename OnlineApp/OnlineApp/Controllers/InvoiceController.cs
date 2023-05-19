using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineApp.Models.Classes;

namespace OnlineApp.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Invoices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FetchInvoice(int id)
        {
            var values = context.Invoices.Find(id);
            return View("FetchInvoice",values);
        }

        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var invo = context.Invoices.Find(invoice.InvoiceId);
            invo.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            invo.InvoiceOrderNumber = invoice.InvoiceOrderNumber;
            invo.InvoiceDate = invoice.InvoiceDate;
            invo.Time = invoice.Time;
            invo.TaxAdministration = invoice.TaxAdministration;
            invo.Deliverer = invoice.Deliverer;
            invo.Recipient = invoice.Recipient;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            var values = context.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            var inv = context.Invoices.Where(x => x.InvoiceId == id).Select(y => y.InvoiceSerialNumber+""+y.InvoiceOrderNumber).FirstOrDefault();
            ViewBag.d = inv;
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInvoiceItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem invoiceItem)
        {
            context.InvoiceItems.Add(invoiceItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}