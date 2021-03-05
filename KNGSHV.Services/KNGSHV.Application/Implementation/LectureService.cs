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
    public class LectureService : ILectureService
    {
        private readonly IRepository<Lecture, Guid> _lectureRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public LectureService (IRepository<Lecture, Guid> lectureRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _lectureRepository = lectureRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(LectureViewModel lectureView)
        {
            var lecture = _mapper.Map<Lecture>(lectureView);

            _lectureRepository.Add(lecture);
        }

        public void Delete(Guid lectureId)
        {
            var lecture = _lectureRepository.FindSingle(x => x.Id == lectureId);

            _lectureRepository.Remove(lecture);
        }

        public LectureViewModel GetById(Guid lectureId)
        {
            var lecture = _lectureRepository.FindSingle(x => x.Id == lectureId);
            var lectureView = _mapper.Map<LectureViewModel>(lecture);
            return lectureView;
        }

        public List<LectureViewModel> GetLectures()
        {
            var lectures = _lectureRepository.GetAll().ToList();
            var lectureViews = _mapper.Map<List<LectureViewModel>>(lectures);
            return lectureViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(LectureViewModel lectureView)
        {
            var lecture = _mapper.Map<Lecture>(lectureView);

            _lectureRepository.Update(lecture);
        }
    }
}
