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
        private readonly ForumContext _context;
        public CommentRepository(ForumContext context)
        {
            _context = context;
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
