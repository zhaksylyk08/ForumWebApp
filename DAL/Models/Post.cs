using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Post : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int Views { get; set; }

        public int Votes { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int? CommunityId { get; set; }
        public Community Community { get; set; }
    }
}
