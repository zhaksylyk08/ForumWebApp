using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.ViewModels.Post;

namespace ForumProject.ViewModels.Community
{
    public class CommunityDetailsViewModel
    {
        public CommunityViewModel Community { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
