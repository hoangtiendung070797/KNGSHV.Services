using KNGSHV.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.ViewModels
{
    public class FunctionViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public Status Status { get; set; }
    }
}
