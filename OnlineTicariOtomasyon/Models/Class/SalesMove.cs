using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class SalesMove
    {   [Key]
        public int Id { get; set; }
        public DateTime _Date { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Product  Product { get; set; }
        public virtual Current  Current { get; set; }



    }
}