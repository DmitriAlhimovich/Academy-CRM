using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.Get(id);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}