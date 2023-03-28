using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var list = context.Invoices.ToList();
         

            return View(list);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()

        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)

        {
            string sonFatura = context.Invoices.OrderByDescending(f => f.RowNo).Select(f => f.RowNo).FirstOrDefault();
            string yeniFaturaNo;
            if (sonFatura == null || sonFatura.Substring(0, 4) != DateTime.Now.Year.ToString())
            {
                yeniFaturaNo = DateTime.Now.Year.ToString() + "0000000001";
            }
            else
            {
                int siraNo = int.Parse(sonFatura.Substring(4));
                siraNo++;
                yeniFaturaNo = sonFatura.Substring(0, 4) + siraNo.ToString("D9");

            }

            


            invoice.SerialNo = char.Parse("A").ToString();
            invoice.RowNo = yeniFaturaNo;
            invoice._Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            invoice._Time = Convert.ToString(DateTime.Now.ToShortTimeString());
            context.Invoices.Add(invoice);
            context.SaveChanges();
        
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            var result = context.InvoiceExpenses.Where(x => x.Invoice.Id == id).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult NewInvoiceExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewInvoiceExpense(InvoiceExpense expense)
        {


            context.InvoiceExpenses.Add(expense);
            context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}