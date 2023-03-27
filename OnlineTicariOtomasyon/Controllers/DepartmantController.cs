using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmantController : Controller
    {
        // GET: Departmant
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Departments.Where(c => c.Status == true).ToList();
            return View(result);
        }
         [HttpGet]
        public ActionResult DepartmantAdd( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmantAdd(Department department)
        {
            var result = context.Departments.Add(department);
            result.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmantDelete(int id)
        {
            var result = context.Departments.Find(id);
            result.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartmant(int id)
        {
            var departmant = context.Departments.Find(id);
            return View("GetDepartmant", departmant);

        }
        public ActionResult DepartmantEdit(Department dep)
        {
            var result = context.Departments.Find(dep.Id);
            result.DepartmentName = dep.DepartmentName;
            result.Description = dep.Description;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DepartmantDetail(int id)
        {
            var result = context.Employees.Where(x => x.Id == id).ToList();
            var departmentName = context.Departments.Where(x => x.Id == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.value = departmentName;
            return View(result);
        }
        public ActionResult EmployeeSales(int id)
        {
            var result = context.SalesMoves.Where(x => x.EmployeeId == id).ToList();
            var emp = context.Employees.Where(c => c.Id == id).Select(y => y.EmployeeName +" " +y.EmployeeSurname).FirstOrDefault();

            ViewBag.employee = emp;
            return View(result);
        }
    }
}