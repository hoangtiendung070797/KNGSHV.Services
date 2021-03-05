using KNGSHV.Data.Enums;
using KNGSHV.Data.Interfaces;
using KNGSHV.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Data.Entities
{
    public class LectureSchedule : DomainEntity<Guid>, IDateTracking, IHasSoftDelete, ISwitchable
    {
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

        public Lecture Lecture { get; set; }

        public Guid LeanerId { get; set; }

        public Learner Learner { get; set; }

        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
