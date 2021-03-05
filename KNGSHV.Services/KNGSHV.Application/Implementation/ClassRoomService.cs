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
    public class ClassRoomService : IClassRoomService
    {
        private readonly IRepository<ClassRoom, Guid> _classRoomRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ClassRoomService(IRepository<ClassRoom, Guid> classRoomRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(ClassRoomViewModel classRoomView)
        {
            var classRoom = _mapper.Map<ClassRoom>(classRoomView);
            _classRoomRepository.Add(classRoom);
        }

        public void Delete(Guid classRoomId)
        {
            var classRoom = _classRoomRepository.FindSingle(x => x.Id == classRoomId);
            _classRoomRepository.Remove(classRoom);
        }

        public ClassRoomViewModel GetById(Guid classRoomId)
        {
            var classRoom = _classRoomRepository.FindSingle(x => x.Id == classRoomId);
            var classRoomView = _mapper.Map<ClassRoomViewModel>(classRoom);
            return classRoomView;
        }

        public List<ClassRoomViewModel> GetClassRooms()
        {
            var classRooms = _classRoomRepository.GetAll().ToList();
            var classRoomViews = _mapper.Map<List<ClassRoomViewModel>>(classRooms);
            return classRoomViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ClassRoomViewModel classRoomView)
        {
            var classRoom = _mapper.Map<ClassRoom>(classRoomView);
            _classRoomRepository.Update(classRoom);
        }
    }
}
