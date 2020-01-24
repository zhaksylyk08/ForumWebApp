using System;
using System.Collections.Generic;
using System.Text;
using DAL.Data;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ForumContext context) : base(context)
        {

        }
    }
}
