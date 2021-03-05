using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IFeedbackService
    {
        void Add(FeedbackViewModel feedbackView);

        void Update(FeedbackViewModel feedbackView);

        void Delete(Guid feedbackId);

        List<FeedbackViewModel> GetFeedbacks();

        FeedbackViewModel GetById(Guid feedbackId);

        void SaveChanges();
    }
}
