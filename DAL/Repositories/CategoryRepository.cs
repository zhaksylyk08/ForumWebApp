using DAL.Interfaces;
using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ForumContext _context;

        public CategoryRepository(ForumContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            var result = _context.Categories
                .Include(category => category.Communities)
                .ToList();

            return result;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }
    }
}
