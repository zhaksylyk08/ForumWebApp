using ForumProject.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
