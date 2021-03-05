using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface ILectureService
    {
        void Add(LectureViewModel lectureView);

        void Update(LectureViewModel lectureView);

        void Delete(Guid lectureId);

        List<LectureViewModel> GetLectures();

        LectureViewModel GetById(Guid lectureId);

        void SaveChanges();
    }
}
