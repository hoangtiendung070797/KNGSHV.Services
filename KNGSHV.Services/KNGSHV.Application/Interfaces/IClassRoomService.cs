using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface IClassRoomService
    {
        void Add(ClassRoomViewModel classRoomView);

        void Update(ClassRoomViewModel classRoomView);

        void Delete(Guid classRoomId);

        List<ClassRoomViewModel> GetClassRooms();

        ClassRoomViewModel GetById(Guid classRoomId);

        void SaveChanges();
    }
}
