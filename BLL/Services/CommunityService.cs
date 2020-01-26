using BLL.Interfaces;
using DAL.Repositories;
using DAL.Data;
using DAL.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BLL.Services
{
    public class CommunityService : CommunityRepository, ICommunityService
    {
        public CommunityService(ForumContext context) : base(context)
        {

        }

        public void CreateCommunity(Community community, IFormFile file, string rootPath)
        {
            string uploadsFolder = Path.Combine(rootPath, "images", "communities");

            if (file != null)
            {
                string uniqueFileName = community.Id.ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));

                community.PhotoPath = uniqueFileName;
            }
            else  //default image for communities
            {
                community.PhotoPath = "default.jpg";
            }

            base.Add(community);
        }
    }
}
