using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using ForumProject.ViewModels.Post;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using DAL.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels;
using ForumProject.ViewModels.Community;

namespace ForumProject.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly ICommunityService _communityService;
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        private readonly UserManager<User> _userManager;

        public CommunityController(ICommunityService communityService, ICategoryService categoryService,
            UserManager<User> userManager, IWebHostEnvironment appEnvironment, IPostService postService)
        {
            _communityService = communityService;
            _categoryService = categoryService;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
            _postService = postService;
        }

        [HttpGet]
        [Route("/communities/{id?}")]
        public IActionResult Index(int? id)
        {
            // id is for categoryId
            var categories = _categoryService.GetAll()
                .Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name })
                .ToList();

            var communities = _communityService.GetAll()
                .Select(c => new CommunityViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    PhotoPath = c.PhotoPath,
                    CategoryId = c.CategoryId
                });

            // to display all communities
            categories.Insert(0, new CategoryViewModel { Id = 0, Name = "All" });

            var viewModel = new CommunityIndexViewModel { Categories = categories, Communities = communities };

            if (id != null && id > 0)
            {
                viewModel.Communities = communities.Where(c => c.CategoryId == id);
            }
            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("/community/create")]
        public IActionResult Create()
        {
            // to choose one of categories in selectlist
            var categories = _categoryService.GetAll()
                .Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name });

            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("/community/create")]
        public async Task<IActionResult> Create(CreateCommunityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // to get creator of community
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userId);

                var category = _categoryService.GetById(viewModel.CategoryId);

                var community = new Community
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Created = DateTime.Now,
                    Category = category,
                    Creator = user
                };
                // to separate image storage logic
                _communityService.CreateCommunity(community, viewModel.Photo, _appEnvironment.WebRootPath);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login or(and) password");
            }

            return View(viewModel);
        }

        [HttpGet]
        [Route("/community/{id}")]
        public IActionResult Details(int id)
        {
            var community = _communityService.GetById(id);
            var posts = _postService.GetPostsByCommunity(community.Id);

            var communityViewModel = new CommunityViewModel
            {
                Id = community.Id,
                Title = community.Title,
                Description = community.Description,
                PhotoPath = community.PhotoPath,
                CategoryId = community.CategoryId
            };

            var postList = posts.Select(post => new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.AuthorId,
                Created = post.Created.ToString(),
                Views = post.Views,
                Score = post.Score,
                CommentsCount = post.Comments.Count(),
                Community = communityViewModel
            });

            var viewModel = new CommunityDetailsViewModel
            {
                Community = communityViewModel,
                Posts = postList
            };

            return View(viewModel);
        }
    }
}