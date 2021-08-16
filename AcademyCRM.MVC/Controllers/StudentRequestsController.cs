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
    public class StudentRequestsController : Controller
    {
        private readonly IEntityService<StudentRequest> _requestService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentRequestsController(IMapper mapper, IStudentService studentService, ICourseService courseService, IEntityService<StudentRequest> requestService)
        {
            _mapper = mapper;
            _studentService = studentService;
            _courseService = courseService;
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            var requests = _requestService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentRequestModel>>(requests));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue ? _mapper.Map<StudentRequestModel>(_requestService.GetById(id.Value)) : new StudentRequestModel(){Created = DateTime.Today};
            ViewBag.Courses = _mapper.Map<IEnumerable<CourseModel>>(_courseService.GetAll());
            ViewBag.Students = _mapper.Map<IEnumerable<StudentModel>>(_studentService.GetAll());
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<StudentRequest>(model);
                if (model.Id > 0)
                    _requestService.Update(request);
                else
                    _requestService.Create(request);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public void Delete(int id)
        {

            _requestService.Delete(id);
        }
    }
}
