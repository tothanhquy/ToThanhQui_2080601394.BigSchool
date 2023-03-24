using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToThanhQui_2080601394.Models;

namespace ToThanhQui_2080601394.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; } = -1;
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureTime]
        public string Time { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime(){ 
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public string Heading { get; set; }
        public string Action
        {
            get
            {
                return Id == -1 ? "Create" : "Edit";
            }
        }

}
}