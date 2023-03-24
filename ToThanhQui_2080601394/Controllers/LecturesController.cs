using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToThanhQui_2080601394.Models;
using ToThanhQui_2080601394.ViewModels;

namespace ToThanhQui_2080601394.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LecturesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Lectures
        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();

            var lectures = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee).Distinct()
                .ToList();

            return View(lectures);
        }
    }
}