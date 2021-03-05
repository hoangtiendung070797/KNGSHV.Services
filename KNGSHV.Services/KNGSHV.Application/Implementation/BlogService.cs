using AutoMapper;
using KNGSHV.Application.Interfaces;
using KNGSHV.Application.ViewModels;
using KNGSHV.Data.Entities;
using KNGSHV.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace KNGSHV.Application.Implementation
{
    public class BlogService : IBlogService
    {

        private readonly IRepository<Blog, Guid> _blogRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public BlogService(IRepository<Blog, Guid> blogRepository , IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(BlogViewModel blogView)
        {
            var blog = _mapper.Map<Blog>(blogView);
            _blogRepository.Add(blog);
        }

        public void Delete(Guid blogId)
        {
            var blog = _blogRepository.FindSingle(x => x.Id == blogId);
            _blogRepository.Remove(blog);
        }

        public List<BlogViewModel> GetBlogs()
        {
            var blogs = _blogRepository.GetAll().ToList();
            var blogViews = _mapper.Map<List<BlogViewModel>>(blogs);
            return blogViews;
        }

        public BlogViewModel GetById(Guid blogId)
        {
            var blogs = _blogRepository.FindSingle(x=>x.Id == blogId);
            var blogViews = _mapper.Map<BlogViewModel>(blogs);
            return blogViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(BlogViewModel blogView)
        {
            var blog = _mapper.Map<Blog>(blogView);
            _blogRepository.Update(blog);
        }
    }
}
