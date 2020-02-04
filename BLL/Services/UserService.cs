using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Data;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<int> GetOveralPostsScoreAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Posts)
                .SingleAsync(u => u.Id == userId);

            var postsScoreSum = 0;

            foreach (var post in user.Posts)
            {
                postsScoreSum += post.Score;
            }

            return postsScoreSum;
        }

        public async Task<int> GetCommentsCountAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Comments)
                .SingleAsync(u => u.Id == userId);

            return user.Comments.Count();
        }

        public async Task<int> GetPostsCountAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Posts)
                .SingleAsync(u => u.Id == userId);

            return user.Posts.Count();
        }
    }
}
