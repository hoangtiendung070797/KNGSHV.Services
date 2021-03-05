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
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRepository<RegistrationForm, Guid> _registrationFormRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RegistrationFormService (IRepository<RegistrationForm, Guid> registrationFormRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _registrationFormRepository = registrationFormRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(RegistrationFormViewModel registrationFormView)
        {
            var registrationForm = _mapper.Map<RegistrationForm>(registrationFormView);
            _registrationFormRepository.Add(registrationForm);
        }

        public void Delete(Guid registrationFormId)
        {
            var registrationForm = _registrationFormRepository.FindSingle(x => x.Id == registrationFormId);
            _registrationFormRepository.Remove(registrationForm);
        }

        public RegistrationFormViewModel GetById(Guid registrationFormId)
        {
            var registrationForm = _registrationFormRepository.FindSingle(x => x.Id == registrationFormId);
            var registrationFormView = _mapper.Map<RegistrationFormViewModel>(registrationForm);
            return registrationFormView;
        }

        public List<RegistrationFormViewModel> GetregistrationForms()
        {
            var registrationForms = _registrationFormRepository.GetAll().ToList();
            var registrationFormViews = _mapper.Map<List<RegistrationFormViewModel>>(registrationForms);
            return registrationFormViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(RegistrationFormViewModel registrationFormView)
        {
            var registrationForm = _mapper.Map<RegistrationForm>(registrationFormView);
            _registrationFormRepository.Update(registrationForm);
        }
    }
}
