using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.ViewModels;

namespace ForumProject.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int Views { get; set; }
        public int Score { get; set; }
        public int CommentsCount { get; set; }

        public string Created { get; set; }

        public CommunityViewModel Community { get; set; }

        //public int CommunityId { get; set; }
        //public string CommunityTitle { get; set; }
    }
}
