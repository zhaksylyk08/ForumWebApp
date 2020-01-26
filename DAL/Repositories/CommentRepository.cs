using System;
using System.Collections.Generic;
using System.Text;
using DAL.Data;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public CommentRepository(ForumContext context)
        {

        }
    }
}
