using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;
using PagedList;
using PagedList.Mvc;


namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        OnlineTicariOtomasyon.Models.Class.Context context = new Models.Class.Context();
        // GET: Category
        public ActionResult Index(int page=1)
        {
            var results = context.Categories.Where(c => c.Status == true).ToList().ToPagedList(page,10);
            return View(results);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            category.CreatedDate = DateTime.Now;
            category.Status = true;
            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CategoryDelete(int id)
        {
            var result = context.Categories.Find(id);
            result.Status = false;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var result = context.Categories.Find(id);
            return View("GetCategory", result);

        }

        public ActionResult CategoryEdit(Category category)

        {
            var result = context.Categories.Find(category.Id);
            result.CategoryName = category.CategoryName;
            result.Description = category.Description;
            result.UpdatedDate = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }


}