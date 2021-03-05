using KNGSHV.Data.Enums;
using KNGSHV.Data.Interfaces;
using KNGSHV.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Data.Entities
{
    public class Feedback : DomainEntity<Guid>, IDateTracking, ISwitchable
    {
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Status Status { get; set; }
    }
}
