using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToThanhQui_2080601394.Models;

namespace ToThanhQui_2080601394.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourses { get;set; }
        public List<string> FollowingLecturersId { get;set; }
        public List<int> AttendingCoursesId { get;set; }
        public bool ShowAction { get; set; }
    }
}