using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ToThanhQui_2080601394.Models;
using ToThanhQui_2080601394.ViewModels;

namespace ToThanhQui_2080601394.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var upcomingCourses = _dbContext.Courses
                .Include(a => a.Lecturer)
                .Include(a => a.Category)
                .Where(a => a.DateTime > DateTime.Now);

            var lecturesId = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee.Id).Distinct()
                .ToList();

            var coursesId = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course.Id)
                .ToList();

            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = upcomingCourses,
                FollowingLecturersId = lecturesId,
                AttendingCoursesId = coursesId,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}