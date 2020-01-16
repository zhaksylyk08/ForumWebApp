using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Comment : BaseModel
    {
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}
