using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
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
        public IActionResult Edit(int id)
        {
            var student = _studentsService.GetById(id);

            ViewBag.Groups = _mapper.Map<IEnumerable<StudentGroupModel>>(_groupService.GetAll());

            return View(_mapper.Map<StudentModel>(student));
        }

        [HttpPost]
        public IActionResult Edit(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                _studentsService.Update(_mapper.Map<Student>(studentModel));
                return RedirectToAction("Index");
            }
            return View(studentModel);

            
        }
    }
}
