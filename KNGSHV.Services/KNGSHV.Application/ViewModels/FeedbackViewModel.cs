using KNGSHV.Data.Enums;
using System;

namespace KNGSHV.Application.ViewModels
{
    public class FeedbackViewModel
    {

        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Status Status { get; set; }
    }
}
