using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ToThanhQui_2080601394.ViewModels
{
    public class FutureTime: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var check = DateTime.TryParseExact(Convert.ToString(value), "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out date);
            return check;
        }
    }
}