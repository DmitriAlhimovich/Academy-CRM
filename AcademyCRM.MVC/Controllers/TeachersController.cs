using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AcademyCRM.BLL.Services;
using AcademyCRM.Core.Models;
using AcademyCRM.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCRM.MVC.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public TeachersController(ITeacherService teacherService, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
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

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int id, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var path = "/Files/" + uploadedFile.FileName;
                
                // save file to file system
                await using var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);

                await uploadedFile.CopyToAsync(fileStream);

                //save file to DB (Person)
                await using var memoryStream = new MemoryStream();

                await uploadedFile.CopyToAsync(memoryStream);

                var content = memoryStream.ToArray();

                _teacherService.SavePhoto(id, content);
            }

            return RedirectToAction("Index");
        }
    }
}