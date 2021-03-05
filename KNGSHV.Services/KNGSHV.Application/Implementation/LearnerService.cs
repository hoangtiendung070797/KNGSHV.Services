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
    public class LearnerService : ILearnerService
    {
        private readonly IRepository<Learner, Guid> _learnerRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public LearnerService (IRepository<Learner, Guid> learnerRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _learnerRepository = learnerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(LearnerViewModel learnerView)
        {
            var learner = _mapper.Map<Learner>(learnerView);
            _learnerRepository.Add(learner);
        }

        public void Delete(Guid learnerId)
        {
            var learner = _learnerRepository.FindSingle(x => x.Id == learnerId);
            _learnerRepository.Remove(learner);
        }

        public LearnerViewModel GetById(Guid learnerId)
        {
            var learner = _learnerRepository.FindSingle(x => x.Id == learnerId);
            var learnerView = _mapper.Map<LearnerViewModel>(learner);
            return learnerView;
        }

        public List<LearnerViewModel> GetLearners()
        {
            var learners = _learnerRepository.GetAll().ToList();
            var learnerViews = _mapper.Map<List<LearnerViewModel>>(learners);
            return learnerViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(LearnerViewModel learnerView)
        {
            var learner = _mapper.Map<Learner>(learnerView);
            _learnerRepository.Update(learner);
        }
    }
}
