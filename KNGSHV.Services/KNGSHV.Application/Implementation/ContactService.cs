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
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact, Guid> _contactRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ContactService(IRepository<Contact, Guid> contactRepository
            , IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(ContactViewModel contactView)
        {
            var contact = _mapper.Map<Contact>(contactView);
            _contactRepository.Add(contact);
        }

        public void Delete(Guid contactId)
        {
            var contact = _contactRepository.FindSingle(x => x.Id == contactId);
            _contactRepository.Remove(contact);
        }

        public ContactViewModel GetById(Guid contactId)
        {
            var contact = _contactRepository.FindSingle(x=>x.Id == contactId);
            var contacView = _mapper.Map<ContactViewModel>(contact);
            return contacView;
        }

        public List<ContactViewModel> GetContacts()
        {
            var contacts = _contactRepository.GetAll().ToList();
            var contacViews = _mapper.Map<List<ContactViewModel>>(contacts);
            return contacViews;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ContactViewModel contactView)
        {
            var contact = _mapper.Map<Contact>(contactView);
            _contactRepository.Update(contact);
        }
    }
}
