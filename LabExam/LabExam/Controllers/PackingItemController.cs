using LabExam.Auth;
using LabExam.DTOs;
using LabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam.Controllers
{
    [Customer]
    public class PackingItemController : Controller
    {
        //Database
        LAB_AEntities1 db = new LAB_AEntities1();

        //Convert
        public static PackingItem Convert(PackingItemDTO c)
        {
            return new PackingItem
            {
                ItemId = c.ItemId,
                TId = c.TId,
                ItemName = c.ItemName,
                Quantity = c.Quantity,
                Packed = c.Packed,
            };
        }
        public static PackingItemDTO Convert(PackingItem c)
        {
            return new PackingItemDTO
            {
                ItemId = c.ItemId,
                TId = c.TId,
                ItemName = c.ItemName,
                Quantity = c.Quantity,
                Packed = c.Packed,
            };
        }
        public static List<PackingItemDTO> Convert(List<PackingItem> cs)
        {
            var list = new List<PackingItemDTO>();
            foreach (var c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        //List
        public ActionResult Index()
        {
            var data = db.TripPlans.ToList();
            return View(TripPlanController.Convert(data));
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PackingItemDTO obj)
        {
            if (ModelState.IsValid)
            {
                var trips = Convert(obj);
                db.PackingItems.Add(trips);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        private object Convert(List<TripPlan> data)
        {
            throw new NotImplementedException();
        }

        public ActionResult List()
        {
            var data = db.PackingItems.ToList();
            return View(Convert(data));
        }

        //packing details
        public ActionResult Pd(int id)
        {
            var data = (from order in db.TripPlans
                        where order.TripId == id
                        select order).ToList();

            return View(Convert(data));
        }
        
    }
}