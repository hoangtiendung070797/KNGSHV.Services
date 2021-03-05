using KNGSHV.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.ViewModels
{
    public class BlogViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public Guid BlogTypeId { get; set; }

        public BlogType BlogType { get; set; }

        public Guid CreatedUserId { get; set; }

        public Account Account { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
