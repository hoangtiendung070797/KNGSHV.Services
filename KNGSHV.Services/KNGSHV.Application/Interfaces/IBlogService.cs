using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IBlogService
    {
        void Add(BlogViewModel blogView);

        void Update(BlogViewModel blogView);

        void Delete(Guid blogTypeId);

        List<BlogViewModel> GetBlogs();

        BlogViewModel GetById(Guid blogTypeId);

        void SaveChanges();
    }
}
