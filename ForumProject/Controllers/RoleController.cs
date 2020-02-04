using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using ForumProject.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="admin")]
        [HttpGet]
        [Route("/role/create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("/role/create")]
        public async Task<IActionResult> Create(RoleCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole<int>
                {
                    Name = viewModel.RoleName
                };

                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [Authorize(Roles="admin")]
        [Route("/role/edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = "Role cannot be found";
                return View("NotFound");
            }

            var viewModel = new RoleEditViewModel
            {
                Id = role.Id,
                Name = role.Name
            };

            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    viewModel.Users.Add(user.UserName);
                }
            }

            return View(viewModel);
        }

        [Authorize(Roles="admin")]
        [Route("/role/edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewModel viewModel)
        {
            var role = await _roleManager.FindByIdAsync(viewModel.Id.ToString());

            if (role == null)
            {
                ViewBag.ErrorMesage = "Role cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = viewModel.Name;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
            }

            return View(viewModel);
        }
    }
}