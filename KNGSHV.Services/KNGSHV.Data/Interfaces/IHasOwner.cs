using System;

namespace KNGSHV.Data.Interfaces
{
    public interface IHasOwner
    {
        Guid UserId { get; set; }
    }
}
