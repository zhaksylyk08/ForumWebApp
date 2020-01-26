using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
    }
}
