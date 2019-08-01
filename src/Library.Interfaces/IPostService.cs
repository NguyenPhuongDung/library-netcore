using System;
using System.Collections.Generic;
using System.Text;

using Library.Entities;
using Library.Models.Request.User;

namespace Library.Interfaces
{
    public interface IPostService
    {
        void Add(PostRequest post);
        void Update(PostRequest post);
        void Delete(int id);
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int postId);
    }
}
