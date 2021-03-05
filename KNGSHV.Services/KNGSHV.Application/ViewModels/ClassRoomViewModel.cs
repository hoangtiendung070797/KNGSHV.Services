using KNGSHV.Data.Entities;
using KNGSHV.Data.Enums;
using System;

namespace KNGSHV.Application.ViewModels
{
    public class ClassRoomViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid CreatedUserId { get; set; }

        public Account Account { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public Status Status { get; set; }
    }
}
