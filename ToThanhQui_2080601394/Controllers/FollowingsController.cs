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
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto foll)
        {
            var userId = User.Identity.GetUserId();
            if (db.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == foll.FolloweeId))
            {
                return BadRequest("attendances already exist!");
            }

            var fol = new Following
            {
                FolloweeId = foll.FolloweeId,
                FollowerId = userId
            };

            db.Followings.Add(fol);
            db.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Unfollow(string FolloweeId)
        {
            var userId = User.Identity.GetUserId();
            if (db.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == FolloweeId))
            {
                var followee = db.Followings.First(a => a.FollowerId == userId && a.FolloweeId == FolloweeId);
                if(followee!=null)db.Followings.Remove(followee);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Followee not exist!");
            }

            
        }
    }
}
