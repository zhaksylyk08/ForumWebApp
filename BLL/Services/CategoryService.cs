using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Repositories;
using DAL.Data;

namespace BLL.Services
{
    public class CategoryService : CategoryRepository, ICategoryService
    {
        public CategoryService(ForumContext context) : base(context)
        {

        }
    }
}
