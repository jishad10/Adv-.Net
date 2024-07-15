using LabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.DTOs
{
    public class TripPlanDTO
    {
        public int TripId { get; set; }
        public int UserID { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Budget { get; set; }
        public string Status { get; set; }
        public virtual User User { get; set; }
    }
}