using System;
using System.Collections.Generic;
using System.Text;

using Library.Entities;

namespace Library.Interfaces
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int postId);
    }
}
