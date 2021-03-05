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
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course, Guid> _courseRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CourseService(IRepository<Course, Guid> courseRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CourseViewModel courseView)
        {
            var course = _mapper.Map<Course>(courseView);
            _courseRepository.Add(course);
        }

        public void Delete(Guid courseId)
        {
            var course = _courseRepository.FindSingle(x => x.Id == courseId);
            _courseRepository.Remove(course);
        }

        public CourseViewModel GetById(Guid courseId)
        {
            var course = _courseRepository.FindSingle(x => x.Id == courseId);
            var courseView = _mapper.Map<CourseViewModel>(course);
            return courseView;
        }

        public List<CourseViewModel> GetCourse()
        {
            var courses = _courseRepository.GetAll().ToList();
            var courseViews = _mapper.Map<List<CourseViewModel>>(courses);
            return courseViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CourseViewModel courseView)
        {
            var course = _mapper.Map<Course>(courseView);
            _courseRepository.Update(course);
        }
    }
}
