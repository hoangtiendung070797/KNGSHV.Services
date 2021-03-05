using KNGSHV.Data.Enums;
using KNGSHV.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace KNGSHV.Data.Entities
{
    public class Function : IdentityRole<Guid>, IDateTracking, IHasSoftDelete, ISwitchable
    {

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public Status Status { get; set; }
    }
}
