using DAL.Interfaces;
using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumContext context) : base(context)
        {

        }
    }
}
