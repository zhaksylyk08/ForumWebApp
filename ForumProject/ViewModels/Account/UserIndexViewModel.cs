using DAL.Models;
using ForumProject.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject.ViewModels.Account
{
    public class UserIndexViewModel
    {
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public IEnumerable<UserViewModel> Moderators { get; set; }
        public IEnumerable<UserViewModel> Candidates { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
