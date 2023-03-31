using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult LoginPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult LoginPartial(Current current)
        {

            context.Currents.Add(current);
            current.CurrentDescription = "Login partial üzerinden eklenmiştir";
            current.Status = true;
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult CurrentPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult CurrentPartial(Current current)
        {
            var results = context.Currents.FirstOrDefault(x => x.Email == current.Email && x.CurrentPassword == current.CurrentPassword);
            if (results != null)
            {
                FormsAuthentication.SetAuthCookie(results.Email, false);
                Session["Email"] = results.Email.ToString();
                return RedirectToRoutePermanent("CurrentPanel", "Cari")
            }
            else
            {
                return PartialView();
            }

        }
    }
}