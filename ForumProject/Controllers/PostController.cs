using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels.Post;
using ForumProject.ViewModels.Comment;

namespace ForumProject.Controllers
{
    [AllowAnonymous]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var post = _postService.GetById(id);
            var comments = post.Comments.Select(c => new CommentViewModel
            {
               Id = c.Id,
               AuthorId = c.Id,
               AuthorName = c.Author.DisplayName,
               Content = c.Content,
               Created = c.Created,
               PostId = c.Post.Id
            });
            var viewModel = new PostDetailsViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.AuthorId,
                AuthorName = post.Author.DisplayName,
                Created = post.Created,
                Content = post.Content,
                Comments = comments
            };

            return View(viewModel);
        }
    }
}