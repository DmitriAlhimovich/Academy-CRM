using Microsoft.AspNetCore.Mvc;
using SampleMVCWebApp.Models;
using SampleMVCWebApp.Services;

namespace SampleMVCWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentsService;

        public StudentsController(IStudentService studentService)
        {
            _studentsService = studentService;
        }

        public IActionResult Index()
        {
            var students = _studentsService.GetAll();
            return View(new StudentListModel(students));
        }
    }
}
