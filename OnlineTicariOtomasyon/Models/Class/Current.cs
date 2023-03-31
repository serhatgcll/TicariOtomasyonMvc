using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Current
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CurrentDescription { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string City { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string CurrentPassword { get; set; }
        public bool Status { get; set; }

        public ICollection<SalesMove> SalesMoves { get; set; }

    }
}