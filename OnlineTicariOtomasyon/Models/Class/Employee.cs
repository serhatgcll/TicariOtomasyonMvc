using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeSurname { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }

        public int DepartmantId { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }
      

        public virtual Department Department { get; set; }



    }
}