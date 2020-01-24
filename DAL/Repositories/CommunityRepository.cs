using DAL.Interfaces;
using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {
        public CommunityRepository(ForumContext context) : base(context)
        {

        }
    }
}
