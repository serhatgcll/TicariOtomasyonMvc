using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineTicariOtomasyon.Controllers
{

    public class EmployeeController : Controller
    {
        Context _context = new Context();
        // GET: Employee

        public ActionResult Index()
        {
            var result = _context.Employees.Where(x => x.Status == true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> listItems = (from x in _context.Departments.Where(y => y.Status == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Value = x.Id.ToString() ,
                                                  Text = x.DepartmentName

                                              }).ToList();
            ViewBag.value = listItems;



            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            var result = _context.Employees.Add(employee);
            result.Status = true;
            result.CreatedDate = DateTime.Now;
           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeGet(int id)
        {

            List<SelectListItem> listItems = (from x in _context.Departments.Where(y => y.Status == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.DepartmentName

                                              }).ToList();
            ViewBag.val = listItems;



            var res = _context.Employees.Find(id);
            return View("EmployeeGet", res);
        }

        public ActionResult UpdateEmployee(Employee employee)
        {
            var result = _context.Employees.Find(employee.Id);
            result.EmployeeName = employee.EmployeeName;
            result.EmployeeSurname = employee.EmployeeSurname;
            result.ImageUrl = employee.ImageUrl;
            result.DepartmantId = employee.DepartmantId;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EmployeeDelete(int id)
        {
            var result = _context.Employees.Find(id);
            result.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       

    }

}