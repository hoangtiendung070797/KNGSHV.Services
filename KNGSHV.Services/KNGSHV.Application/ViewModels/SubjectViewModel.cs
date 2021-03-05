using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.ViewModels
{
    public class SubjectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public Status Status { get; set; }

        public Guid CreatedUserId { get; set; }

        public Account Account { get; set; }

        public List<LectureSchedule> LectureSchedules { get; set; }
    }
}
