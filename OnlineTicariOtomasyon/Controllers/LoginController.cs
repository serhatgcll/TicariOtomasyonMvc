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
        public ActionResult LoginPartial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPartial(Current current)
        {

            context.Currents.Add(current);
            current.CurrentDescription = "Login partial üzerinden eklenmiştir";
            current.Status = true;
            context.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult CurrentPartial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentPartial(Current current)
        {
            var results = context.Currents.FirstOrDefault(x => x.Email == current.Email && x.CurrentPassword == current.CurrentPassword);
            if (results != null)
            {
                FormsAuthentication.SetAuthCookie(results.Email, false);
                Session["Email"] = results.Email.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}