using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Context context = new Context();
        public ActionResult Index(string q, int page = 1)
        {
            var product = from x in context.Products select x;
            if (!string.IsNullOrEmpty(q))
            {
                product = product.Where(y => y.ProductName.Contains(q) || y.Brand.Contains(q));
            }
            return View(product.ToList().ToPagedList(page, 8));
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
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                product.İmageUrl = "/Image/" + fileName + extension;
            }
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

        public ActionResult ReportWizardProduct()
        {

            var result = context.Products.ToList();
            return View(result);
        }


    }
}