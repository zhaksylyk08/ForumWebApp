using ForumProject.ViewModels.Comment;
using System;
using System.Collections.Generic;

namespace ForumProject.ViewModels.Post
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool IsEditedByModerator { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
