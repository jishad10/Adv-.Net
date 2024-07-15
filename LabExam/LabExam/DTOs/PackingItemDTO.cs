using LabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.DTOs
{
    public class PackingItemDTO
    {
        public int ItemId { get; set; }
        public int TId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Packed { get; set; }

        public virtual TripPlan TripPlan { get; set; }
    }
}