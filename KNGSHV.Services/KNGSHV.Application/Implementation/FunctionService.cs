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
    public class FunctionService : IFunctionService
    {
        private readonly IRepository<Function, Guid> _functionRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public FunctionService(IRepository<Function, Guid> functionRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _functionRepository = functionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(FunctionViewModel functionView)
        {
            var function = _mapper.Map<Function>(functionView);
            _functionRepository.Add(function);
        }

        public void Delete(Guid functionId)
        {
            var function = _functionRepository.FindSingle(x => x.Id == functionId);
            _functionRepository.Remove(function);
        }

        public FunctionViewModel GetById(Guid functionId)
        {
            var function = _functionRepository.FindSingle(x => x.Id == functionId);
            var functionView = _mapper.Map<FunctionViewModel>(function);
            return functionView;
        }

        public List<FunctionViewModel> GetFunctions()
        {
            var functions = _functionRepository.GetAll().ToList();
            var functionViews = _mapper.Map<List<FunctionViewModel>>(functions);
            return functionViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FunctionViewModel functionView)
        {
           // var function = _mapper.Map<Function>(functionView);
            var currentFunction = _functionRepository.FindSingle(x => x.Id == functionView.Id);
            currentFunction.Name = functionView.Name;
            currentFunction.DateCreated = functionView.DateCreated;
            currentFunction.DateModified = functionView.DateModified;
            currentFunction.IsDeleted = functionView.IsDeleted;
            currentFunction.Status = functionView.Status;
            _functionRepository.Update(currentFunction);
        }
    }
}
