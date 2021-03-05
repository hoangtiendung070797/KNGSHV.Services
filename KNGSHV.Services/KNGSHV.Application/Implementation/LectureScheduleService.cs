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
    public class LectureScheduleService : ILectureScheduleService
    {
        private readonly IRepository<LectureSchedule, Guid> _lectureScheduleRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public LectureScheduleService (IRepository<LectureSchedule, Guid> lectureScheduleRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _lectureScheduleRepository = lectureScheduleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(LectureScheduleViewModel lectureScheduleView)
        {
            var lectureSchedule = _mapper.Map<LectureSchedule>(lectureScheduleView);
            _lectureScheduleRepository.Add(lectureSchedule);
        }

        public void Delete(Guid lectureScheduleId)
        {
            var lectureSchedule = _lectureScheduleRepository.FindSingle(x => x.Id == lectureScheduleId);
            _lectureScheduleRepository.Remove(lectureSchedule);
        }

        public LectureScheduleViewModel GetById(Guid lectureScheduleId)
        {
            var lectureSchedule = _lectureScheduleRepository.FindSingle(x => x.Id == lectureScheduleId);
            var lectureScheduleView = _mapper.Map<LectureScheduleViewModel>(lectureSchedule);
            return lectureScheduleView;
        }

        public List<LectureScheduleViewModel> GetLectureSchedules()
        {
            var lectureSchedules = _lectureScheduleRepository.GetAll().ToList();
            var lectureScheduleViews = _mapper.Map<List<LectureScheduleViewModel>>(lectureSchedules);
            return lectureScheduleViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(LectureScheduleViewModel lectureScheduleView)
        {
            var lectureSchedule = _mapper.Map<LectureSchedule>(lectureScheduleView);
            _lectureScheduleRepository.Update(lectureSchedule);
        }
    }
}
