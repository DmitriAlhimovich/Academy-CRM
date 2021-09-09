using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.Api.Dto;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL.Dapper.Queries;
using AutoMapper;
using MediatR;

namespace AcademyCRM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CoursesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> Get()
        {
            var data = await _mediator.Send(new GetCoursesListQuery());
            return _mapper.Map<IEnumerable<CourseDto>>(data);
        }

        [HttpGet("byId")]
        public async Task<CourseDto> GetById(int id)
        {
            return _mapper.Map<CourseDto>(await _mediator.Send(new GetCourseByIdQuery(id)));
        }

        [HttpPut]
        public async Task Update(CourseDto course)
        {
            await _mediator.Send(new UpdateCourseCommand(_mapper.Map<Course>(course)));
        }
    }
}
