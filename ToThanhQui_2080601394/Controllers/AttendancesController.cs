using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToThanhQui_2080601394.DTOs;
using ToThanhQui_2080601394.Models;

namespace ToThanhQui_2080601394.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto atte)
        {
            var userId = User.Identity.GetUserId();
            if(db.Attendances.Any(a => a.AttendeeId == userId&& a.CourseId == atte.CourseId))
            {
                return BadRequest("attendances already exist!");
            }

            var att = new Attendance { 
                CourseId = atte.CourseId,
                AttendeeId = userId
            };

            db.Attendances.Add(att);
            db.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Unattend(int courseId)
        {
            var userId = User.Identity.GetUserId();
            if (db.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == courseId))
            {
                var attend = db.Attendances.First(a => a.AttendeeId == userId && a.CourseId == courseId);
                if (attend != null) db.Attendances.Remove(attend);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Attend not exist!");
            }


        }
    }
}
