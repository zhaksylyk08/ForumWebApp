using System;
using System.Collections.Generic;
using System.Text;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ForumContext _context;         

        public UserRepository(ForumContext context)
        {
            _context = context;
        }


    }
}
