using KNGSHV.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.Interfaces
{
    public interface ICourseService
    {
        void Add(CourseViewModel courseView);

        void Update(CourseViewModel courseView);

        void Delete(Guid courseId);

        List<CourseViewModel> GetCourse();

        CourseViewModel GetById(Guid courseId);

        void SaveChanges();

    }
}
