using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Community> CreatedCommunities { get; set; }
        public virtual ICollection<UserCommunity> SubscribedCommunities { get; set; }
    }
}
