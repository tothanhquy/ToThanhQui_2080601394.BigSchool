using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToThanhQui_2080601394.Models;
using ToThanhQui_2080601394.ViewModels;

namespace ToThanhQui_2080601394.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();

            var lecturesId = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee.Id).Distinct()
                .ToList();



            var viewModel = new CoursesViewModel
            {
                UpcomingCourses = courses,
                FollowingLecturersId = lecturesId,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Courses
                .Where(a => a.LecturerId == userId && a.DateTime>DateTime.Now && !a.IsCancel)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();


            return View(courses);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Heading = "Add Course"
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            if(!ModelState.IsValid)
            {
                courseViewModel.Categories = _dbContext.Categories.ToList();
                return View("Create",courseViewModel);
            }
            var course = new Course()
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = courseViewModel.GetDateTime(),
                CategoryId = courseViewModel.Category,
                Place = courseViewModel.Place,
                IsCancel = false
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            
            return RedirectToAction("Mine","Courses");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(a=>a.Id == id&&a.LecturerId==userId);

            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Date = course.DateTime.ToString("dd/M/yyyy"),
                Time = course.DateTime.ToString("HH:mm"),
                Category = course.CategoryId,
                Place = course.Place,
                Heading = "Edit Course",
                Id = id
            };
            return View("Create",viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                courseViewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", courseViewModel);
            }

            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(a => a.Id == courseViewModel.Id && a.LecturerId == userId);
            course.DateTime = courseViewModel.GetDateTime();
            course.CategoryId = courseViewModel.Category;
            course.Place = courseViewModel.Place;

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}