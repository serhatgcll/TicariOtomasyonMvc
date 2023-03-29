using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context context = new Context();
        public ActionResult Index()
        {
            var list = context.ToDoLists.ToList();
            return View(list);
        }
    }
}