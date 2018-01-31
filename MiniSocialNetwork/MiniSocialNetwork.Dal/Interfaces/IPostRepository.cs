﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Dal.Interfaces
{
    public interface IPostRepository
    {
        void Create(Post post);
        void DeleteAsync(String id);
        IQueryable<Post> GetAll();
    }
}
