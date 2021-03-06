using AcademyCRM.Api.Dto;
using AcademyCRM.Core.Models;
using AutoMapper;

namespace AcademyCRM.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
        }
    }
}
