using AcademyCRM.Angular.Dto;
using AcademyCRM.Core.Models;
using AutoMapper;

namespace AcademyCRM.Angular.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(model => model.TopicName, map => map.MapFrom(c => c.CourseCategory.Title))
                .ReverseMap();
        }
    }
}
