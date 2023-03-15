using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
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
            var cource = new Course()
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = courseViewModel.GetDateTime(),
                CategoryId = courseViewModel.Category,
                Place = courseViewModel.Place,
            };
            _dbContext.Courses.Add(cource);
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index","Home");
        }
    }
}