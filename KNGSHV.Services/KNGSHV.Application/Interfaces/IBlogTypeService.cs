using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IBlogTypeService
    {
        void Add(BlogTypeViewModel blogTypeView);

        void Update(BlogTypeViewModel blogTypeView);

        void Delete(Guid blogTypeId);

        List<BlogTypeViewModel> GetAccounts();

        BlogTypeViewModel GetById(Guid blogTypeId);

        void SaveChanges();
    }
}
