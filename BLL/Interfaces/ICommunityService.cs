using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;

namespace BLL.Interfaces
{
    public interface ICommunityService : ICommunityRepository
    {
        void CreateCommunity(Community community, IFormFile file, string rootPath);
    }
}
