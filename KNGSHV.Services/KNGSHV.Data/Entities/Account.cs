using KNGSHV.Data.Enums;
using KNGSHV.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace KNGSHV.Data.Entities
{
    public class Account : IdentityUser<Guid>, IDateTracking, IHasSoftDelete, ISortable, ISwitchable
    {
        public Account() : base() { }

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