using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IContactService
    {
        void Add(ContactViewModel contactView );

        void Update(ContactViewModel contactView);

        void Delete(Guid contactId);

        List<ContactViewModel> GetContacts();

        ContactViewModel GetById(Guid contactId);

        void SaveChanges();
    }
}
