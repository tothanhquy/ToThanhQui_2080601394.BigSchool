using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToThanhQui_2080601394.Models;

namespace ToThanhQui_2080601394.ViewModels
{
    public class CourseViewModel
    {
        private string time;
        private string date;
        private string place;

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Place
        {
            get
            {
                return place;
            }

            set
            {
                place = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }


        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime(){ 
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }



}
}