﻿using CrudPractice1.Auth;
using CrudPractice1.DTOs;
using CrudPractice1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudPractice1.Controllers
{

    public class CategoryController : Controller
    {   
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
            var list = new List<CategoryDTO>();      //Initializes a new empty list of type CategoryDTO
            foreach (var c in cs)
            {
                list.Add(Convert(c)); 
            }
            return list;
        }

        // GET: Category
        PMS_Sum24_AEntities db = new PMS_Sum24_AEntities();
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Categories.Find(id);
            return View(Convert(exobj));
        }

        [HttpPost]
        public ActionResult Edit(CategoryDTO c)
        {
            if (ModelState.IsValid)
            {
                var exobj = db.Categories.Find(c.Id);
                exobj.Name = c.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}