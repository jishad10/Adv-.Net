using IntroApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroApi.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/student/all")]
        public HttpResponseMessage AllStudents()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "data");
        }
        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage SingleStudent(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, " Single sudent " + id);
        }

        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage CreateStudent(Student s)
        {
            //db object create
            //db.Students.Add(s);
            //db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Created");

        }
    }
}
