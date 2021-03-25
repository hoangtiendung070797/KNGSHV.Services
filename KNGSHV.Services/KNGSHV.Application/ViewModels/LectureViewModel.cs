using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.ViewModels
{
    public class LectureViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Sex { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public string Level { get; set; }

        public string Note { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }

        public Guid CreatedUserId { get; set; }

        public Guid? AccountId { get; set; }

        public Account Account { get; set; }

        public List<LectureSchedule> LectureSchedules { get; set; }
    }
}
