using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var results = context.SalesMoves.ToList();
            return View(results);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> value = (from x in context.Products.Where(y => y.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.ProductName,
                                              Value=x.Id.ToString()
                                          }).ToList();

            List<SelectListItem> value2 = (from x in context.Currents.Where(y => y.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CurrentName+" "+x.CurrentSurname,
                                              Value = x.Id.ToString()
                                          }).ToList();

            List<SelectListItem> value3 = (from x in context.Employees.Where(y => y.Status == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.Id.ToString()
                                           }).ToList();

            ViewBag.prod = value;
            ViewBag.current = value2;
            ViewBag.emp = value3;

            return View();
        }

        [HttpPost]
        public ActionResult NewSale(SalesMove sales)
        {
            sales.Date_=DateTime.Parse (DateTime.Now.ToShortDateString());
         
            
            context.SalesMoves.Add(sales);
           
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleDetail(int id)
        {
            var result = context.SalesMoves.Where(x => x.Id == id).ToList();
            return View(result);
        }
    }
}