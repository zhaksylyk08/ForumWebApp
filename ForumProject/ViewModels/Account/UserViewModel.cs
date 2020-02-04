using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.ViewModels.Account
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public int PostsCount { get; set; }
        public int CommentsCount { get; set; }
        public int OveralPostsScore { get; set; }
    }
}
