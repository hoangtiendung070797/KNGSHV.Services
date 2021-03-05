using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IRegistrationFormService
    {
        void Add(RegistrationFormViewModel registrationFormView);

        void Update(RegistrationFormViewModel registrationFormView);

        void Delete(Guid registrationFormId);

        List<RegistrationFormViewModel> GetregistrationForms();

        RegistrationFormViewModel GetById(Guid registrationFormId);

        void SaveChanges();
    }
}
