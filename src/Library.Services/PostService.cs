using System;
using System.Collections.Generic;
using System.Text;

using Library.Entities;
using Library.Interfaces;

namespace Library.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Add(Post Post)
        {
            _unitOfWork.PostRepository.Add(Post);
            _unitOfWork.Save();

        }
        public void Update(Post Post)
        {
            _unitOfWork.PostRepository.Edit(Post);
            _unitOfWork.Save();

        }
        public void Delete(int id)
        {
            var org = _unitOfWork.PostRepository.FindById(id);
            _unitOfWork.PostRepository.Delete(org);
            _unitOfWork.Save();
        }
        public IEnumerable<Post> GetAllPosts()
        {
            return _unitOfWork.PostRepository.GetAll();
        }
        public Post GetPost(int PostId)
        {
            return _unitOfWork.PostRepository.FindById(PostId);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();

        }

    }
}
