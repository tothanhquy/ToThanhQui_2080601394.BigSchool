using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToThanhQui_2080601394.Models
{
    public class Category
    {

        public byte Id { get; set; }
        [Required]

        [StringLength(255)]

        public string Name { get; set; }


    }
}