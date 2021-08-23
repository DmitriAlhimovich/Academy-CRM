using System.Collections.Generic;
using AcademyCRM.Angular.Dto;
using AcademyCRM.BLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCRM.Angular.Controllers
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
            var res = _mapper.Map<IEnumerable<CourseDto>>(_service.GetAll());
            return res;
        }
    }
}
