using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumProject
{
    public class DataSeeder
    {
        private ForumContext _context;
        RoleManager<IdentityRole<int>> _roleManager;
        UserManager<User> _userManager;

        public DataSeeder(ForumContext context, RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // assigns admin role to user
        public async Task Initialize()
        {
            var isAdminRole = await _roleManager.RoleExistsAsync("admin");

            if (!isAdminRole)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole<int> { Name = "admin" });
            }

            var hasAdminUser = await _userManager.FindByNameAsync("admin");

            if (hasAdminUser != null)
            {
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
