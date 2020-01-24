using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        public DateTime Created { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Community> CreatedCommunities { get; set; }
        public virtual ICollection<UserCommunity> SubscribedCommunities { get; set; }
    }
}
