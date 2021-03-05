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
    public class BlogTypeService : IBlogTypeService
    {

        private readonly IRepository<BlogType, Guid> _blogTypeRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public BlogTypeService(IRepository<BlogType, Guid> blogTypeRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _blogTypeRepository = blogTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(BlogTypeViewModel blogTypeView)
        {
            var blogType = _mapper.Map<BlogType>(blogTypeView);
            _blogTypeRepository.Add(blogType);
        }

        public void Delete(Guid blogTypeId)
        {
            var blogType = _blogTypeRepository.FindSingle(x => blogTypeId == x.Id);
            _blogTypeRepository.Remove(blogType);
        }

        public List<BlogTypeViewModel> GetAccounts()
        {
            var blogTypes = _blogTypeRepository.GetAll().ToList();
            var blogTypeViews = _mapper.Map<List<BlogTypeViewModel>>(blogTypes);
            return blogTypeViews;
        }

        public BlogTypeViewModel GetById(Guid blogTypeId)
        {
            var blogTypes = _blogTypeRepository.FindSingle(x => x.Id == blogTypeId);
            var blogTypeViews = _mapper.Map<BlogTypeViewModel>(blogTypes);
            return blogTypeViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(BlogTypeViewModel blogTypeView)
        {
            var blogTypes = _mapper.Map<BlogType>(blogTypeView);
            _blogTypeRepository.Update(blogTypes);
                
        }
    }
}
