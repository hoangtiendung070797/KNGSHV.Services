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
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<Feedback, Guid> _feedbackRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public FeedbackService(IRepository<Feedback, Guid> feedbackRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(FeedbackViewModel feedbackView)
        {
            var feedback = _mapper.Map<Feedback>(feedbackView);
            _feedbackRepository.Add(feedback);
        }

        public void Delete(Guid feedbackId)
        {
            var feedback = _feedbackRepository.FindSingle(x => x.Id == feedbackId);
            _feedbackRepository.Remove(feedback);
        }

        public FeedbackViewModel GetById(Guid feedbackId)
        {
            var feedback = _feedbackRepository.FindSingle(x => x.Id == feedbackId);
            var feedbackView = _mapper.Map<FeedbackViewModel>(feedback);
            return feedbackView;
        }

        public List<FeedbackViewModel> GetFeedbacks()
        {
            var feedbacks = _feedbackRepository.GetAll().ToList();
            var feedbackViews = _mapper.Map<List<FeedbackViewModel>>(feedbacks);
            return feedbackViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FeedbackViewModel feedbackView)
        {
            var feedback = _mapper.Map<Feedback>(feedbackView);
            _feedbackRepository.Update(feedback);
        }
    }
}
