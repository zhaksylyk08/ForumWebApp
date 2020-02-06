using BLL.Interfaces;
using DAL.Models;
using ForumProject.ViewModels.Comment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ForumProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public CommentController(ICommentService commentService, UserManager<User> userManager,
            IPostService postService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("comment/create/")]
        public async Task<JsonResult> Create(CommentCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userId);

                var post = _postService.GetById(viewModel.PostId);

                var comment = new Comment
                {
                    Content = viewModel.Content,
                    Post = post,
                    Author = user,
                    Created = DateTime.Now
                };

                _commentService.Add(comment);
                return Json(true);
            }

            return Json(false);
        }
    }
}