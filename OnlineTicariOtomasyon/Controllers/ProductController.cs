using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Products.Where(p => p.Status == true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> result = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.Id.ToString()
                                           }).ToList();

            ViewBag.value = result;

            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.Status = true;
            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ProductDelete(int id)
        {
            var result = context.Products.Find(id);
            result.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {

            List<SelectListItem> res = (from x in context.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.Id.ToString()
                                        }).ToList();

            ViewBag.value = res;


            var result = context.Products.Find(id);
            return View("GetProduct", result);
        }
      
        public ActionResult ProductEdit(Product prod)
        {

            var result = context.Products.Find(prod.Id);
            result.ProductName = prod.ProductName;
            result.Brand = prod.Brand;
            result.Description = prod.Description;
            result.BuyingPrice = prod.BuyingPrice;
            result.SellingPrice = prod.SellingPrice;
            result.İmageUrl = prod.İmageUrl;
            result.Stock = prod.Stock;
            result.UpdatedDate = DateTime.Now;
            result.Status = prod.Status;
            result.CategoryId = prod.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}