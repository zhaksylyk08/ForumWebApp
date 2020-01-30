using System.ComponentModel.DataAnnotations;

namespace ForumProject.ViewModels.Role
{
    public class RoleCreateViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
