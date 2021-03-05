using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IFunctionService
    {
        void Add(FunctionViewModel  functionView);

        void Update(FunctionViewModel functionView);

        void Delete(Guid functionId);

        List<FunctionViewModel> GetFunctions();

        FunctionViewModel GetById(Guid functionId);

        void SaveChanges();
    }
}
