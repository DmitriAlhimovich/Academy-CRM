using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCRM.MVC.Controllers
{
    public class StudentGroupsController : Controller
    {
        private readonly IStudentGroupService _groupService;
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService groupService, ITeacherService teacherService, IMapper mapper)
        {
            _groupService = groupService;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentGroupModel>>(groups));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var group = _groupService.GetById(id);

            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(_teacherService.GetAll());

            return View(_mapper.Map<StudentGroupModel>(group));
        }

        [HttpPost]
        public IActionResult Edit(StudentGroupModel groupModel)
        {
            _groupService.Update(_mapper.Map<StudentGroup>(groupModel));

            return RedirectToAction("Index");
        }
    }
}