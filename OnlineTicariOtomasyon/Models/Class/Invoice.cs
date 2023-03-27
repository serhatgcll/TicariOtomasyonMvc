using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string RowNo { get; set; }
        public DateTime _Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TaxOffice { get; set; }
        public DateTime _Time { get; set; }

        public ICollection<InvoiceExpense> InvoiceExpenses { get; set; }

    }
}