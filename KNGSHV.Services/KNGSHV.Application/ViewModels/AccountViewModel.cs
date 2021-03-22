using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using System;
using System.Collections.Generic;

namespace KNGSHV.Application.ViewModels
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string PasswordHash { get; set; }

        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<ClassRoom> ClassRooms { get; set; }

        public List<Learner> Learners { get; set; }

        public List<Lecture> Lectures { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
