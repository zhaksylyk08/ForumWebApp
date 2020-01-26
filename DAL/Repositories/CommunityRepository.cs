using DAL.Interfaces;
using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly ForumContext _context;

        public CommunityRepository(ForumContext context) 
        {
            _context = context;
        }

        public void Add(Community community)
        {
            _context.Add(community);
            _context.SaveChanges();
        }

        public IEnumerable<Community> GetAll()
        {
            var result = _context.Communities
                .Include(community => community.Posts)
                .ToList();

            return result;
        }

        public Community GetById(int id)
        {
            var community = _context.Communities.Where(c => c.Id == id)
                .Include(c => c.Posts)
                    .ThenInclude(p => p.Author)
                .Include(c => c.Posts)
                    .ThenInclude(p => p.Comments)
                        .ThenInclude(comment => comment.Author)
                .FirstOrDefault();

            return community;
        }
    }
}
