using ForumProject.ViewModels.Account;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumProject.ViewModels.Role
{
    public class RoleEditViewModel
    {
        public RoleEditViewModel()
        {
            Users = new List<string>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Role name")]
        public string Name { get; set; }

        public List<string> Users { get; set; }
    }
}
