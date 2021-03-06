using System.Collections.Generic;
using AcademyCRM.BLL.Services;
using AcademyCRM.Core.Models;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AcademyCRM.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentsService;
        private readonly IStudentGroupService _groupService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IStudentGroupService groupService, IMapper mapper)
        {
            _studentsService = studentService;
            _groupService = groupService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var students = _studentsService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentModel>>(students));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = id.HasValue
                ? _mapper.Map<StudentModel>(_studentsService.GetById(id.Value))
                : new StudentModel();

            ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(_groupService.GetAll());

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(studentModel);
                if (studentModel.Id > 0)
                    _studentsService.Update(student);
                else
                    _studentsService.Create(student);
                
                return RedirectToAction("Index");
            }
            return View(studentModel);


        }
    }
}
