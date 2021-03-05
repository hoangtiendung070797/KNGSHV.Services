using AutoMapper;
using KNGSHV.Application.Interfaces;
using KNGSHV.Application.ViewModels;
using KNGSHV.Data.Entities;
using KNGSHV.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KNGSHV.Application.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account, Guid> _accountRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly UserManager<Account> _userManager;
       
        public AccountService(IRepository<Account, Guid> accountRepository,
           IUnitOfWork unitOfWork, IMapper mapper, UserManager<Account> userManager)
        {
            _accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }


        public void Add(AccountViewModel accountView)
        {
            var account = _mapper.Map<Account>(accountView);
            _accountRepository.Add(account);
        }

        public void Delete(Guid accountId)
        {
            var account = _accountRepository.FindSingle(x => accountId == x.Id);
            _accountRepository.Remove(account);
        }

        public List<AccountViewModel> GetAccounts()
        {
            List<Account> accounts = _accountRepository.GetAll().ToList();
            var accountVm = _mapper.Map<List<AccountViewModel>>(accounts);
            return accountVm;

        }

  

        public void Update(AccountViewModel accountView)
        {
            var account = _mapper.Map<Account>(accountView);
            var currentAccount = _accountRepository.FindSingle(x => x.Id == account.Id);

            currentAccount.FullName = account.FullName;
            currentAccount.Avatar = account.Avatar;
            currentAccount.BirthDay = account.BirthDay;
            currentAccount.Email = account.Email;
            currentAccount.PhoneNumber = account.PhoneNumber;
            _accountRepository.Update(currentAccount);

        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public AccountViewModel GetById(Guid accountId)
        {
            var account =  _accountRepository.FindSingle(x => accountId == x.Id);

            var accountVm = _mapper.Map<AccountViewModel>(account);

            return accountVm;
        }
    }
}
