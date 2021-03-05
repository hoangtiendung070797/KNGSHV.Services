using KNGSHV.Data.Enums;
using KNGSHV.Data.Interfaces;
using KNGSHV.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Data.Entities
{
    public class Course : DomainEntity<Guid>, IDateTracking, IHasSoftDelete, ISwitchable
    {
        public string Name { get; set; }       

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public Status Status { get; set; }
    }
}
