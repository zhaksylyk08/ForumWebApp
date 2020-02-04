using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(ForumContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
