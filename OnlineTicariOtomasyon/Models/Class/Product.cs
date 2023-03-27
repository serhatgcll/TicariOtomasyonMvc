using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Brand { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string İmageUrl { get; set; }
        public short Stock { get; set; }
        public bool CriticalCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<SalesMove> SalesMoves
        {
            get; set;


        }

    }
}