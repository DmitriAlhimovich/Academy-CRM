using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using AcademyCRM.MVC.Configuration;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IEntityService<Topic> _topicService;
        private readonly IConfiguration _configuration;
        private readonly SecurityOptions _securityOptions;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService,
            IMapper mapper, 
            IEntityService<Topic> topicService, 
            IConfiguration configuration,
            IOptions<SecurityOptions> options
            )
        {
            _mapper = mapper;
            _topicService = topicService;
            _configuration = configuration;
            _securityOptions = options.Value;
            _courseService = courseService;

        }

        public IActionResult Index()
        {
            var email = _securityOptions.AdminUserEmail;
            var email2 = _configuration["Security:ManagerUserEmail"];
            var students = _courseService.GetAll();
            return View(_mapper.Map<IEnumerable<CourseModel>>(students));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue ? _mapper.Map<CourseModel>(_courseService.GetById(id.Value)) : new CourseModel();
            ViewBag.Topics = _mapper.Map<IEnumerable<TopicModel>>(_topicService.GetAll());
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseModel);
                if (courseModel.Id > 0)
                    _courseService.Update(course);
                else
                    _courseService.Create(course);
                return RedirectToAction("Index");
            }
            return View(courseModel);
        }
    }
}
