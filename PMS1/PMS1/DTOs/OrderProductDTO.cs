using PMS1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS1.DTOs
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int PId { get; set; }
        public int OId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}