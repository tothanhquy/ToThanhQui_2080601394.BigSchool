using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToThanhQui_2080601394.Models
{
    public class Following
    {
        public ApplicationUser Follower { get; set; }
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        public ApplicationUser Followee { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }
    }
}