using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using DAL.Data;
using BLL.Interfaces;

namespace BLL.Services
{
    public class PostService : PostRepository, IPostService
    {
        public PostService(ForumContext context) : base(context)
        {

        }


    }
}
