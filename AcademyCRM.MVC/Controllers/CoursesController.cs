using System.Collections.Generic;
using AcademyCRM.BLL.Services;
using AcademyCRM.Core.Models;
using AcademyCRM.Core.Models.Filters;
using AcademyCRM.MVC.Configuration;
using AcademyCRM.MVC.Filters;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AcademyCRM.MVC.Controllers
{
    [TypeFilter(typeof(LocalExceptionFilter), Order = int.MinValue)]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IEntityService<Topic> _topicService;
        private readonly IStudentRequestService _requestService;
        private readonly IConfiguration _configuration;
        private readonly SecurityOptions _securityOptions;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService,
            IMapper mapper,
            IEntityService<Topic> topicService,
            IStudentRequestService requestService,
            IConfiguration configuration,
            IOptions<SecurityOptions> options
            )
        {
            _mapper = mapper;
            _topicService = topicService;
            _requestService = requestService;
            _configuration = configuration;
            _securityOptions = options.Value;
            _courseService = courseService;

        }

        public IActionResult Index()
        {
            var courses = _courseService.GetAll();
            var models = _mapper.Map<IEnumerable<CourseModel>>(courses);

            foreach (var model in models)
            {
                model.RequestsCount = _requestService.GetOpenRequestsCountByCourse(model.Id);
            }

            return View(models);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue ? _mapper.Map<CourseModel>(_courseService.GetById(id.Value)) : new CourseModel();

            if (id.HasValue)
                model.Requests = _mapper.Map<IEnumerable<StudentRequestModel>>(_requestService.GetOpenRequestsByCourse(id.Value));

            ViewBag.Topics = _mapper.Map<IEnumerable<TopicModel>>(_topicService.GetAll());
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CourseModel courseModel)
        {
            if (!ModelState.IsValid) return View(courseModel);

            var course = _mapper.Map<Course>(courseModel);
            if (courseModel.Id > 0)
                _courseService.Update(course);
            else
                _courseService.Create(course);
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            var courses = _courseService.Search(search);

            return View("Index", _mapper.Map<IEnumerable<CourseModel>>(courses));
        }

        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> FilterAsync(CourseFilterViewModel model)
        {
            var courses = await _courseService.Filter(_mapper.Map<CourseFilter>(model));

            return View("Index", _mapper.Map<IEnumerable<CourseModel>>(courses));
        }
    }
}
