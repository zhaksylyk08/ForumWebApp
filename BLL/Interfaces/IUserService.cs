using DAL.Models;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<int> GetPostsCountAsync(int userId);
        Task<int> GetCommentsCountAsync(int userId);
    }
}
