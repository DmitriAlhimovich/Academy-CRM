using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.BLL.Extensions;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;

        public CourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Course> GetAll()
        {
            
            return _repository.GetAll();
        }

        public Task<IEnumerable<Course>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Course GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Create(Course course)
        {
            course.Topic = null;
            _repository.Create(course);
        }

        public void Update(Course course)
        {
            _repository.Update(course);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> Search(string search)
        {
            return _repository.Find(c =>
                c.Title.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase) ||
                c.Description.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase));
        }
    }
}