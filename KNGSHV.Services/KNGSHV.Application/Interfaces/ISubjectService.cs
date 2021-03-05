using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface ISubjectService
    {
        void Add(SubjectViewModel subjectView);

        void Update(SubjectViewModel subjectView);

        void Delete(Guid subjectId);

        List<SubjectViewModel> GetSubjects();

        SubjectViewModel GetById(Guid subjectId);

        void SaveChanges();
    }
}
