using System.Collections.Generic;
using AcademyCRM.BLL.Models;

namespace AcademyCRM.BLL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Update(Student student);
    }
}