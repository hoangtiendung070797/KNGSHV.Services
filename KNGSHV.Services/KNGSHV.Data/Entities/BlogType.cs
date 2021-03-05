using KNGSHV.Data.Interfaces;
using KNGSHV.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Data.Entities
{
    public class BlogType : DomainEntity<Guid>, IDateTracking
    {
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get;set; }

        public List<Blog> Blogs { get; set; }
    }
}
