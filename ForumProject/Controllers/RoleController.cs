using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RoleController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/role/create")]
        public IActionResult Create()
        {
            return View();
        }

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
                    return RedirectToAction("", "");
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