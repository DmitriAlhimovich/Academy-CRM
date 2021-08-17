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
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue
                ? _mapper.Map<StudentGroupModel>(_groupService.GetById(id.Value))
                : new StudentGroupModel();

            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherModel>>(_teacherService.GetAll());
            ViewBag.IsAdmin = HttpContext.User.IsInRole("admin");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(StudentGroupModel groupModel)
        {
            var group = _mapper.Map<StudentGroup>(groupModel);
            if (groupModel.Id > 0)
                _groupService.Update(group);
            else
                _groupService.Create(group);

            return RedirectToAction("Index");
        }
    }
}