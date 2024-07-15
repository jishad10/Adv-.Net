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
    [AdminAccess]
    public class TripPlanController : Controller
    {
        //Database
        LAB_AEntities1 db = new LAB_AEntities1();

        //Convert
        public static TripPlan Convert(TripPlanDTO c)
        {
            return new TripPlan
            {
                TripId = c.TripId,
                UserID = c.UserID,
                Tittle = c.Tittle,
                Description = c.Description,
                Date = c.Date,
                Budget = c.Budget,
                Status = c.Status,
            };
        }
        public static TripPlanDTO Convert(TripPlan c)
        {
            return new TripPlanDTO
            {
                TripId = c.TripId,
                UserID = c.UserID,
                Tittle = c.Tittle,
                Description = c.Description,
                Date = c.Date,
                Budget = c.Budget,
                Status = c.Status,
            };
        }
        public static List<TripPlanDTO> Convert(List<TripPlan> cs)
        {
            var list = new List<TripPlanDTO>();
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
            return View(Convert(data));
        }

        //Edit 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.TripPlans.Find(id);
            return View(Convert(exobj));
        }

        [HttpPost]
        public ActionResult Edit(TripPlanDTO c)
        {
            if (ModelState.IsValid)
            {
                var exobj = db.TripPlans.Find(c.TripId);
                exobj.Tittle = c.Tittle;
                exobj.Description = c.Description;
                exobj.Budget = c.Budget;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }


        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TripPlanDTO obj)
        {
            if (ModelState.IsValid)
            {
                var trips = Convert(obj);
                db.TripPlans.Add(trips);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.TripPlans.Find(id);
            db.TripPlans.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Search
        public ActionResult Search(string Search)
        {
            var trips = db.TripPlans.AsQueryable();
            //IQueryable<Product> products = db.Products;

            if (!string.IsNullOrEmpty(Search))
            {
                trips = trips.Where(p =>
                    p.Tittle.Contains(Search) ||
                    p.Description.ToString().Contains(Search) ||
                    p.Budget.ToString().Contains(Search) ||
                    p.Status.ToString().Contains(Search));
            }
            var data = trips.ToList();
            return View("Index", Convert(data));
        }
    }
}