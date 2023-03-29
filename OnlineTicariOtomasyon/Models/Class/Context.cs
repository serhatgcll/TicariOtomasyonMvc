using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceExpense> InvoiceExpenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesMove> SalesMoves { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }


    }
}