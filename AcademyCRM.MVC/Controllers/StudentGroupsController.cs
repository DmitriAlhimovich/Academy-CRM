using System;
using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
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
        public IActionResult Edit(int? id, int? courseId)
        {
            StudentGroupModel model;
            if (id.HasValue)
            {
                var group = _groupService.GetById(id.Value);
                model = _mapper.Map<StudentGroupModel>(group);
                model.Students =_mapper.Map<IEnumerable<StudentModel>>(group.Students);
            }
            else
            {
                if (!courseId.HasValue)
                    throw new ArgumentNullException($"{nameof(courseId)} should have value for group creation");

                model = new StudentGroupModel
                {
                    CourseId = courseId,
                    Students = _mapper.Map<IEnumerable<StudentModel>>(
                        _requestService.GetStudentsByCourse(courseId.Value))
                };
            }

            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(_teacherService.GetAll());
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(_courseService.GetAll());
            ViewBag.IsAdmin = HttpContext.User.IsInRole("admin");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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