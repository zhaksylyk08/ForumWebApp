using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumProject.Models;
using BLL.Interfaces;
using ForumProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels.Post;

namespace ForumProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var posts = _postService.GetAll();

            var postViewModels = posts.Select(post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    AuthorId = post.Author.Id,
                    AuthorName = post.Author.DisplayName,
                    Created = post.Created.ToString(),
                    Views = post.Views,
                    Score = post.Score,
                    Community = new CommunityViewModel
                    {
                        Id = post.Community.Id,
                        Title = post.Community.Title,
                        Description = post.Community.Description,
                        PhotoPath = post.Community.PhotoPath,
                        CategoryId = post.Community.CategoryId
                    }
                });

            return View(new HomeIndexViewModel { Posts = postViewModels});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
