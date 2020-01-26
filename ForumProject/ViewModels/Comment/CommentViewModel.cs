using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}
