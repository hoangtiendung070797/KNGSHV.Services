using AutoMapper;
using KNGSHV.Application.ViewModels;
using KNGSHV.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<AccountViewModel, Account>();

            CreateMap<BlogType, BlogTypeViewModel>();
            CreateMap<BlogTypeViewModel, BlogType>();

            CreateMap<Blog, BlogViewModel>();
            CreateMap<BlogViewModel, Blog>();

            CreateMap<ClassRoom, ClassRoomViewModel>();
            CreateMap<ClassRoomViewModel, ClassRoom>();

            CreateMap<Contact, ContactViewModel>();
            CreateMap<ContactViewModel, Contact>();

            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();

            CreateMap<Feedback, FeedbackViewModel>();
            CreateMap<FeedbackViewModel, Feedback>();

            CreateMap<Function, FunctionViewModel>();
            CreateMap<FunctionViewModel, Function>();

            CreateMap<Learner, LearnerViewModel>();
            CreateMap<LearnerViewModel, Learner>();

            CreateMap<Lecture, LectureViewModel>();
            CreateMap<LectureViewModel, Lecture>();


            CreateMap<Subject, SubjectViewModel>();
            CreateMap<SubjectViewModel, Subject>();


            CreateMap<LectureSchedule, LectureScheduleViewModel>();
            CreateMap<LectureScheduleViewModel, LectureSchedule>();

            CreateMap<RegistrationForm, RegistrationFormViewModel>();
            CreateMap<RegistrationFormViewModel, RegistrationForm>();

        }
    }
}
