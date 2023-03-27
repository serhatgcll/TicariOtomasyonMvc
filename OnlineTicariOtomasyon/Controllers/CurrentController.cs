using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Currents.Where(x => x.Status == true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult CurrentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentAdd(Current current)
        {
            var result = context.Currents.Add(current);
            result.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CurrentDelete(int id)

        {
            var result = context.Currents.Find(id);
            result.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCurrent(int id)
        {
            var current = context.Currents.Find(id);
            return View("GetCurrent", current);


        }
        public ActionResult CurrentEdit(Current current)
        {
            var result = context.Currents.Find(current.Id);
            result.CurrentName = current.CurrentName;
            result.CurrentSurname = current.CurrentSurname;
            result.CurrentDescription = current.CurrentDescription;
            result.Email = current.Email;
            result.Status = current.Status;
            result.City = current.City;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult CurrentSalesHistory(int id)
        {
            var results = context.SalesMoves.Where(x => x.CurrentId == id).ToList();
            var currentName = context.Currents.Where(x => x.Id == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.cr = currentName;
            return View(results);

        }
    }
}