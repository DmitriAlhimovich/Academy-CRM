using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
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
        }
    }
}
