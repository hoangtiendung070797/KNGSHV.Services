using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface ILectureScheduleService
    {
        void Add(LectureScheduleViewModel lectureScheduleView);

        void Update(LectureScheduleViewModel lectureScheduleView);

        void Delete(Guid lectureScheduleId);

        List<LectureScheduleViewModel> GetLectureSchedules();

        LectureScheduleViewModel GetById(Guid lectureScheduleId);

        void SaveChanges();
    }
}
