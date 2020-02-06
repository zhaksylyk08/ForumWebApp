using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.ViewModels.Comment
{
    public class CommentCreateViewModel
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}
