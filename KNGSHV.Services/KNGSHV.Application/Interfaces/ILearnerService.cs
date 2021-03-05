using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface ILearnerService
    {
        void Add(LearnerViewModel learnerView);

        void Update(LearnerViewModel learnerView);

        void Delete(Guid learnerId);

        List<LearnerViewModel> GetLearners();

        LearnerViewModel GetById(Guid learnerId);

        void SaveChanges();
    }
}
