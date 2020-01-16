using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserCommunity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
