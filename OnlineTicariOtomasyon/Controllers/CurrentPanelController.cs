using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        Context context = new Context();
        // GET: CurrentPanel
        [Authorize]

        public ActionResult Index()
        {
            var currentMail = (string)Session["Email"];

            var result = context.Currents.FirstOrDefault(x => x.Email == currentMail);
            ViewBag.current = currentMail;


            return View(result);
        }
        public ActionResult Orders ()
        {
            var currentMail = (string)Session["Email"];
            var id = context.Currents.Where(x => x.Email == currentMail.ToString()).Select(y => y.Id).FirstOrDefault();
            var result = context.SalesMoves.Where(c => c.Current.Id == id).ToList();
            return View(result);
        }
    }
}