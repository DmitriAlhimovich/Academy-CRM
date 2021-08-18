using System;
using System.Collections.Generic;
using System.Linq;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize]
    public class StudentRequestsController : Controller
    {
        private readonly IStudentRequestService _requestService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentRequestsController(IMapper mapper, IStudentService studentService, ICourseService courseService, IStudentRequestService requestService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _courseService = courseService;
            _requestService = requestService;
        }

        public IActionResult Index(bool? includeClosed)
        {
            var requests = includeClosed == true ? _requestService.GetAll() : _requestService.GetAllOpen();
            return View(_mapper.Map<IEnumerable<StudentRequestModel>>(requests));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue ? _mapper.Map<StudentRequestModel>(_requestService.GetById(id.Value)) : new StudentRequestModel() { Created = DateTime.Today };
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(_courseService.GetAll().OrderBy(c => c.Title));
            ViewBag.Students = _mapper.Map<IEnumerable<StudentModel>>(_studentService.GetAll().OrderBy(s => s.LastName));
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var request = _mapper.Map<StudentRequest>(model);
            if (model.Id > 0)
                _requestService.Update(request);
            else
                _requestService.Create(request);
            return RedirectToAction("Index");
        }
    }
}
