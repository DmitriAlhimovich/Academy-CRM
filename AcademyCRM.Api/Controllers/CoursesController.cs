using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AcademyCRM.Api.Dto;
using AcademyCRM.BLL.Services;
using AutoMapper;

namespace AcademyCRM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CourseDto> Get()
        {
            return _mapper.Map<IEnumerable<CourseDto>>(_service.GetAll());
        }

        [HttpGet("byId")]
        public CourseDto GetById(int id)
        {
            return _mapper.Map<CourseDto>(_service.GetById(id));
        }
    }
}
