using PMS1.DTOs;
using PMS1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS1.Controllers
{
    public class CategoryController : Controller
    {   
        //Convert
        public static Category Convert(CategoryDTO c)
        {
            return new Category
            {
                Id = c.Id,
                Name = c.Name,
            };
        }

        public static CategoryDTO Convert(Category c)
        {
            return new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
            };
        }
        public static List<CategoryDTO> Convert(List<Category> cs)
        {
            var list = new List<CategoryDTO>();     
            foreach (var c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }

        PMSEntities db = new PMSEntities();
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(Convert(data));
        }

        //Search
        [HttpPost]
        public ActionResult Search(string Search)
        {
            var data = (from s in db.Categories
                        where s.Name.Contains(Search)
                        select s).ToList();
            return View("Index", Convert(data));
        }
    }
}