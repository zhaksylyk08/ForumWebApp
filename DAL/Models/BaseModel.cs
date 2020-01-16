using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
