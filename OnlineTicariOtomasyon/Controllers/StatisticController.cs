using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();
        public ActionResult Index()
        {
            var currentCount = context.Currents.Count().ToString();
            ViewBag.currentCount = currentCount;

            var productCount = context.Products.Count().ToString();
            ViewBag.productCount = productCount;

            var employeeCount = context.Employees.Count().ToString();
            ViewBag.employeeCount = employeeCount;

            var sumStock = context.Products.Sum(c => c.Stock).ToString();
            ViewBag.sumStock = sumStock;


            List<string> critic = new List<string>();
            foreach (var item in context.Products)
            {
                if (item.Stock <= 20)
                {
                    critic.Add(item.ProductName);
                }


            }
            ViewBag.critic = string.Join(",", critic);







            var brandCount = (from item in context.Products
                              select item.Brand).Distinct().Count().ToString();

            ViewBag.brandCount = brandCount;

            var deg = (from x in context.Products orderby x.SellingPrice descending select x.ProductName).FirstOrDefault();

            ViewBag.deg = deg;


            string currentNameSurname = "";

            var currentWithMostPurchases = context.SalesMoves.GroupBy(s => s.CurrentId).Select(c =>
                new
                {
                    CurrentId = c.Key,
                    TotalPurchases = c.Sum(s => s.Amount)
                }).OrderByDescending(p => p.TotalPurchases).FirstOrDefault();
            if (currentWithMostPurchases != null)
            {
                var current = context.Currents.Where(c => c.Id == currentWithMostPurchases.CurrentId).FirstOrDefault();
                if (current != null)
                {
                    currentNameSurname = $"{current.CurrentName} {current.CurrentSurname}";
                }
            }
            ViewBag.cuurentNameSurname = currentNameSurname;


            string personel = "";

            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var enCokSatisYapanPErsonel = context.SalesMoves.Where(s=>s.Date_>=startOfMonth&&s.Date_<=endOfMonth).GroupBy(c => c.EmployeeId).Select(d =>
            new
            {
                EmployeeId = d.Key,
                TotalSales = d.Sum(s => s.Amount)


            }).OrderByDescending(s => s.TotalSales).FirstOrDefault();

            if (enCokSatisYapanPErsonel != null)
            {
                var sales = context.Employees.Where(s => s.Id == enCokSatisYapanPErsonel.EmployeeId).FirstOrDefault();
                if (sales != null)
                {
                    personel = $"{sales.EmployeeName} {sales.EmployeeSurname}";  
                }
            }
            ViewBag.enCokSatisYapanPersonel = personel;
            return View();
        }
    }
}