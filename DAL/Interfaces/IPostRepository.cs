using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        void Add(Post post);

        IEnumerable<Post> GetPostsByCommunity(int id);
    }
}
