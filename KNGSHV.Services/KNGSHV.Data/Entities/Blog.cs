using KNGSHV.Data.Interfaces;
using KNGSHV.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Data.Entities
{
    public class Blog : DomainEntity<Guid>, IDateTracking
    {
        public string Content { get; set; }

        public Guid BlogTypeId { get; set; }

        public BlogType BlogType { get; set; }

        public Guid CreatedUserId { get; set; }

        public Account Account { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
