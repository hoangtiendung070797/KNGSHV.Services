using AutoMapper;
using KNGSHV.Application.Interfaces;
using KNGSHV.Application.ViewModels;
using KNGSHV.Data.Entities;
using KNGSHV.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNGSHV.Application.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject, Guid> _subjectRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public SubjectService (IRepository<Subject, Guid> subjectRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(SubjectViewModel subjectView)
        {
            var subject = _mapper.Map<Subject>(subjectView);
            _subjectRepository.Add(subject);
        }

        public void Delete(Guid subjectId)
        {
            var subject = _subjectRepository.FindSingle(x => x.Id == subjectId);
            _subjectRepository.Remove(subject);
        }

        public SubjectViewModel GetById(Guid subjectId)
        {
            var subject = _subjectRepository.FindSingle(x => x.Id == subjectId);
            var subjectView = _mapper.Map<SubjectViewModel>(subject);
            return subjectView;
        }

        public List<SubjectViewModel> GetSubjects()
        {
            var subjects = _subjectRepository.GetAll().ToList();
            var subjectViews = _mapper.Map<List<SubjectViewModel>>(subjects);
            return subjectViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SubjectViewModel subjectView)
        {
            var subject = _mapper.Map<Subject>(subjectView);
            _subjectRepository.Update(subject);
        }
    }
}
