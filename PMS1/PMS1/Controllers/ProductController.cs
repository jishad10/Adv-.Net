using PMS1.DTOs;
using PMS1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PMS1.Controllers
{
    public class ProductController : Controller
    {   
        //Database
        PMSEntities db = new PMSEntities();

        //Convert
        public static Product Convert(ProductDTO c)
        {
            return new Product
            {
                Id = c.Id,
                Name = c.Name,
                Qty = c.Qty,
                Price = c.Price,
                CId = c.CId,
            };
        }
        public static ProductDTO Convert(Product c)
        {
            return new ProductDTO
            {
                Id = c.Id,
                Name = c.Name,
                Qty = c.Qty,
                Price = c.Price,
                CId = c.CId,
            };
        }
        public static List<ProductDTO> Convert(List<Product> cs)
        {
            var list = new List<ProductDTO>();
            foreach (var c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        //Product List
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(Convert(data));
        }


        //Edit 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Products.Find(id);
            return View(Convert(exobj));
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO c)
        {
            if (ModelState.IsValid)
            {
                var exobj = db.Products.Find(c.Id);
                exobj.Name = c.Name;
                exobj.Qty = c.Qty;
                exobj.Price = c.Price;
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
        public ActionResult Create(ProductDTO obj)
        {
            if (ModelState.IsValid)
            {
                var product = Convert(obj);
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.Products.Find(id);
            db.Products.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Search
        public ActionResult Search(string Search)
        {
            var products = db.Products.AsQueryable();
            //IQueryable<Product> products = db.Products;

            if (!string.IsNullOrEmpty(Search))
            {
                products = products.Where(p =>
                    p.Name.Contains(Search) ||
                    p.CId.ToString().Contains(Search) ||
                    p.Price.ToString().Contains(Search) ||
                    p.Qty.ToString().Contains(Search));
            }
            var data = products.ToList();
            return View("Index", Convert(data));
        }
    }
}