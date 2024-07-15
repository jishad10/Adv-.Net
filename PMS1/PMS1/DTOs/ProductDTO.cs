using PMS1.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS1.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int CId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}