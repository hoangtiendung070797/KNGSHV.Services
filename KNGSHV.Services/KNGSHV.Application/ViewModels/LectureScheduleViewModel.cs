using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.ViewModels
{
    public class LectureScheduleViewModel
    {
        public Guid Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }

        public int DaysOfWeek { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public Status Status { get; set; }

        public Guid LectureId { get; set; }

        public Guid? LeanerId { get; set; }

        public Guid SubjectId { get; set; }

    }
}
