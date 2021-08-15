using AcademyCRM.BLL.Models;
using AcademyCRM.BLL.Services;
using System.Collections.Generic;

namespace AcademyCRM.MVC
{
    public class FakeCourseService : ICourseService
    {
        public void Create(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            return new[] { new Course { Title = "FakeCourse1" } };
        }

        public Course GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Course entity)
        {
            throw new System.NotImplementedException();
        }
    }
}