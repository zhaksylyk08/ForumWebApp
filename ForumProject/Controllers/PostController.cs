using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ForumProject.ViewModels.Post;
using ForumProject.ViewModels.Comment;
using Microsoft.AspNetCore.Identity;
using DAL.Models;

namespace ForumProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommunityService _communityService;
        private readonly UserManager<User> _userManager;

        public PostController(IPostService postService, ICommunityService communityService,
            UserManager<User> userManager)
        {
            _postService = postService;
            _communityService = communityService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        [Route("/post/create/{communityId}")]
        public IActionResult Create(int communityId)
        {
            var community = _communityService.GetById(communityId);

            var viewModel = new CreatePostViewModel
            {
                CommunityTitle = community.Title,
                CommunityId = community.Id,
                AuthorName = User.Identity.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [Route("post/create/{id}")]
        public async Task<IActionResult> Create(CreatePostViewModel viewModel)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var community = _communityService.GetById(viewModel.CommunityId);

            var post = new Post
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                Created = DateTime.Now,
                Community = community,
                Author = user
            };

            _postService.Add(post);
            return RedirectToAction("Details", "Post", new { id = post.Id});
        }

        [HttpGet]
        [Route("post/details/{id}")]
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
                IsEditedByModerator = post.IsEditedByModerator,
                Comments = comments
            };

            return View(viewModel);
        }

        [Authorize(Roles="admin, moderator")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                ViewBag.ErrorMessage = "Post is not found!";
                return View("NotFound");
            }

            _postService.Delete(post);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles="admin, moderator")]
        [HttpGet]
        [Route("post/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                ViewBag.Message = "Post is not found";
                return View("NotFound");
            }

            var viewModel = new PostEditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.Author.DisplayName,
                Created = post.Created,
                Content = post.Content
            };

            return View(viewModel);
        }

        [Authorize(Roles = "admin, moderator")]
        [HttpPost]
        [Route("post/edit/{id}")]
        public IActionResult Edit(PostEditViewModel viewModel, int id)
        {
            var post = _postService.GetById(id);

            post.Title = viewModel.Title;
            post.Content = viewModel.Content;
            post.IsEditedByModerator = true;

            _postService.Update(post);

            return RedirectToAction("Details", "Post", new { id = id });
        }
    }
}