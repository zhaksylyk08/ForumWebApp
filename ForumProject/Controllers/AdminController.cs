using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using ForumProject.ViewModels.Role;
using ForumProject.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels;
using BLL.Interfaces;

namespace ForumProject.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public AdminController(RoleManager<IdentityRole<int>> roleManager, 
            UserManager<User> userManager, IUserService userService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userService = userService;
        }

        [Route("/administration/users")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.Where(role => role.Name != "admin");
            var roleViewModels = roles.Select(role => new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            });

            var viewModel = new AdminIndexViewModel
            {
                Roles = roleViewModels
            };

            return View(viewModel);
        }

        [Route("/role/users/edit/{roleId}")]
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(int roleId)
        {
            // to return back to role/edit/{id}
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = "Role cannot be found";
                return View("NotFound");
            }

            var viewModel = new List<UserRoleViewModel>();

            foreach (var user in _userManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PostsCount = await _userService.GetPostsCountAsync(user.Id),
                    CommentsCount = await _userService.GetCommentsCountAsync(user.Id)
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                viewModel.Add(userRoleViewModel);
            }
            
            return View(viewModel);
        }

        [Route("/role/users/edit/{roleId}")]
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> viewModel,
            int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());

            foreach (var model in viewModel)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                var result = await _userManager.IsInRoleAsync(user, role.Name);

                if (model.IsSelected && !result)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model.IsSelected && result)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }

            return RedirectToAction("Edit", "Role", new { id = roleId });
        }
    }
}