using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Class
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
    }
}