using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Community : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        public int? CreatorId { get; set; }
        public User Creator { get; set; }

        public virtual ICollection<UserCommunity> Members { get; set; }

        public ICollection<Post> Posts { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
