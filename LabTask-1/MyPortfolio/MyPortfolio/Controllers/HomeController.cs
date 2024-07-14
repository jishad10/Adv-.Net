using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PersonEntity person = new PersonEntity()
            {
                PersonName = "Jahidul Islam Shikdar",
                PersonEmail = "jishad@gmail.com",
                PersonPhoneNumber = "01821518484",
                PersonDegree = "Bachelors",
                PersonExpertise = "C#, C++, JavaScript, NodeJS"
            };

            ViewBag.Person = new PersonEntity[] {person};

            return View();
        }

        public ActionResult Education()
        {
            EducationEntity e1 = new EducationEntity()
            {
                EducationName = "HSC",
                EducationYear = 2019,
                EducationGroup = "Science",
                EducationInstitute = "Cox's Bazar Govt. College"
            };
            EducationEntity e2 = new EducationEntity()
            {
                EducationName = "SSC",
                EducationYear = 2017,
                EducationGroup = "Science",
                EducationInstitute = "Cox's Bazar Govt. School"
            };

            ViewBag.Education = new EducationEntity[] {e1, e2};

            return View();
        }

        public ActionResult Projects()
        {
            ProjectsEntity p1 = new ProjectsEntity()
            {
                ProjectTitle = "Banking Management System",
                ProjectDesc = "A simple command line banking management system",
                ProjectCourse = "OOP1 (Java)"
            };
            ProjectsEntity p2 = new ProjectsEntity()
            {
                ProjectTitle = "Parcel Management System",
                ProjectDesc = "A GUI-based parcel management system",
                ProjectCourse = "OOP2 (C#)"
            };
            ProjectsEntity p3 = new ProjectsEntity()
            {
                ProjectTitle = "Hospital Management System",
                ProjectDesc = "A HTML, CSS, PHP based Web Project for Hospital Management system",
                ProjectCourse = "Webtech"
            };
            ProjectsEntity p4 = new ProjectsEntity()
            {
                ProjectTitle = "SaaS-based Hospital Management System",
                ProjectDesc = "A SaaS Oriented Hospital Management system with Multi-tenency and AI integration",
                ProjectCourse = "Adv. Webtech"
            };

            ViewBag.Projects = new ProjectsEntity[] {p1, p2, p3, p4};

            return View();
        }

        public ActionResult Certifications()
        {
            return View();
        }
        public ActionResult References()
        {
            ReferenceEntity ref1 = new ReferenceEntity()
            {
                Id = 1,
                Name = "MD. AL-AMIN"
            };

            ReferenceEntity ref2 = new ReferenceEntity()
            {
                Id = 2,
                Name = "S M ABDULLAH SHAFI"
            };

            ViewBag.References = new ReferenceEntity[] { ref1, ref2 };
            return View();
        }

        public ActionResult ReferenceDetails(string id)
        {
            ViewBag.RefName = id;
            return View();
        }

    }
}