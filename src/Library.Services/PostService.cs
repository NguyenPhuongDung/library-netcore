using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Library.Entities;
using Library.Interfaces;
using Library.Models.Request.User;

namespace Library.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper Mapper;
        public PostService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public void Add(PostRequest postRequest)
        {
            var post = Mapper.Map<Post>(postRequest);
            _unitOfWork.PostRepository.Add(post);
            _unitOfWork.Save();

        }
        public void Update(PostRequest postRequest)
        {
            var post = Mapper.Map<Post>(postRequest);
            _unitOfWork.PostRepository.Edit(post);
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
