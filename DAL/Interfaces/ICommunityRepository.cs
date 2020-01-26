using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ICommunityRepository
    {
        IEnumerable<Community> GetAll();
        Community GetById(int id);
        void Add(Community community);
    }
}
