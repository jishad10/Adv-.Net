﻿using LabExam.DTOs;
using LabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam.Controllers
{
    public class LoginController : Controller
    {
        LAB_AEntities1 db = new LAB_AEntities1();

        //SignUp
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Uname = model.Uname,
                    Password = model.Password,
                    Gender = model.Gender,
                    Address = model.Address,
                    Type = model.Type
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Uname.Equals(l.Uname) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["Msg"] = "Login Successfull";
                if (user.Type.Equals("Admin"))
                {
                    return RedirectToAction("Index", "TripPlan");
                }
                return RedirectToAction("Index", "PackingItem");
            }
            return View(l);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            TempData["Msg"] = "You have been logged out.";
            return RedirectToAction("Index");
        }

    }
}