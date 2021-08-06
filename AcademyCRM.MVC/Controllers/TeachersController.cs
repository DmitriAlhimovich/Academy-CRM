using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCRM.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var teachers = _teacherService.GetAll();
            return View(_mapper.Map<IEnumerable<TeacherModel>>(teachers));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _teacherService.GetById(id);

            return View(_mapper.Map<TeacherModel>(teacher));
        }

        [HttpPost]
        public IActionResult Edit(TeacherModel teacherModel)
        {
            _teacherService.Update(_mapper.Map<Teacher>(teacherModel));

            return RedirectToAction("Index");
        }
    }
}