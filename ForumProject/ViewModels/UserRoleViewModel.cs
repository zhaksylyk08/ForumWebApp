using ForumProject.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.ViewModels
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int PostsCount { get; set; }
        public int CommentsCount { get; set; }
        public int OveralPostsScore { get; set; }

        public bool IsSelected { get; set; }
    }
}
