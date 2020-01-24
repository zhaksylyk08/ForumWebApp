using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
