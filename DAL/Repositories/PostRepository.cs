﻿using DAL.Interfaces;
using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumContext _context;

        public PostRepository(ForumContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            var result = _context.Posts.ToList();
            return result;
        }

        public Post GetById(int id)
        {
            var post = _context.Posts.Where(p => p.Id == id)
                .Include(p => p.Author)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Author)
                .Include(p => p.Community)
                .FirstOrDefault();

            return post;
        }

        public IEnumerable<Post> GetPostsByCommunity(int id)
        {
            var result = _context.Posts.Where(p => p.CommunityId == id).ToList();
            return result;
        }
    }
}
