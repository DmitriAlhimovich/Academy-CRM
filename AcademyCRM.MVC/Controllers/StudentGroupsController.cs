using System.Collections.Generic;
using AcademyCRM.BLL.Services;
using AcademyCRM.Core.Models;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class StudentGroupsController : Controller
    {
        private readonly IStudentGroupService _groupService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IStudentRequestService _requestService;
        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService groupService, ITeacherService teacherService, ICourseService courseService, IStudentRequestService requestService, IMapper mapper)
        {
            _groupService = groupService;
            _teacherService = teacherService;
            _courseService = courseService;
            _requestService = requestService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentGroupModel>>(groups));
        }

        [HttpGet]
        public IActionResult Create(int courseId)
        {
            var model = new StudentGroupModel
            {
                CourseId = courseId,
                Students = _mapper.Map<IEnumerable<StudentModel>>(_requestService.GetStudentsRequestedForCourse(courseId))
            };

            FillTeachersAndCourses();

            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _mapper.Map<StudentGroupModel>(_groupService.GetById(id));
            FillTeachersAndCourses();
            return View(model);
        }

        private void FillTeachersAndCourses()
        {
            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(_teacherService.GetAll());
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(_courseService.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public IActionResult Edit(StudentGroupModel groupModel)
        {
            if (!ModelState.IsValid) return View(groupModel);

            var group = _mapper.Map<StudentGroup>(groupModel);
            if (groupModel.Id > 0)
                _groupService.Update(group);
            else
                _groupService.Create(group);

            return RedirectToAction("Index");
        }
    }
}