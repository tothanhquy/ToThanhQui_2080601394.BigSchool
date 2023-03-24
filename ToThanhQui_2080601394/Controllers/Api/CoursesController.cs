using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToThanhQui_2080601394.Models;

namespace ToThanhQui_2080601394.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = db.Courses.Single(c=>c.Id == id&&c.LecturerId==userId);

            if (course.IsCancel)
            {
                return NotFound();
            }
            course.IsCancel = true;
            db.SaveChanges();

            return Ok();
        }

    }
}
