using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace KNGSHV.Application.Interfaces
{
    public interface IAccountService
    {

        void Add(AccountViewModel accountView);

        void Update(AccountViewModel accountView);

        void Delete(Guid accountId);

        List<AccountViewModel> GetAccounts();

        AccountViewModel GetById( Guid accountId);

        void SaveChanges();
    }
}
