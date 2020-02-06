using BLL.Interfaces;
using DAL.Data;
using DAL.Repositories;


namespace BLL.Services
{
    public class CommentService : CommentRepository, ICommentService
    {
        public CommentService(ForumContext context) : base(context)
        {

        }


    }
}
