using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Interfaces;
using ForumProject.ViewModels;

namespace ForumProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("/categories")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/categories")]
        public IActionResult Create(CreateCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = viewModel.Name
                };

                _categoryService.Add(category);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login or(and) password");
            }

            return View(viewModel);
        }
    }
}