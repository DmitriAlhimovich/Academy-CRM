using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using System.Collections.Generic;

namespace AcademyCRM.BLL.Tests
{
    public class FakeStudentService : IStudentService
    {
        public IEnumerable<Student> GetAll() =>
            new List<Student>
            {
                new() {FirstName = "Ivan", LastName = "Petrov"},
                new() {FirstName = "Oleg", LastName = "Antonov"}
            };

        public Student GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}