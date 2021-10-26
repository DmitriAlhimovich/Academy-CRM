using AcademyCRM.Core.Filters;
using AcademyCRM.Core.Models;
using AcademyCRM.MVC.Models;
using AutoMapper;

namespace AcademyCRM.MVC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonModel>()
                .ReverseMap();
            CreateMap<Teacher, TeacherModel>()
                .ReverseMap();
            CreateMap<Student, StudentModel>()
                .ReverseMap();
            CreateMap<StudentGroup, StudentGroupModel>()
                //.ForMember(model => model.TeacherName, map => map.MapFrom(g => $"{g.Teacher.FirstName} {g.Teacher.LastName}"))
                .ReverseMap();
            CreateMap<CourseCategory, TopicModel>()
                .ReverseMap();
            CreateMap<Course, CourseModel>()
                .ReverseMap();
            CreateMap<StudentRequest, StudentRequestModel>()
                .ForMember(model => model.StudentName, map => map.MapFrom(r => r.Student.FullName))
                .ForMember(model => model.CourseTitle, map => map.MapFrom(r => r.Course.Title))
                .ReverseMap();
        }
    }
}
