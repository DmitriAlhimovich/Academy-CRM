using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AcademyCRM.BLL.Extensions;
using AcademyCRM.Core.Filters;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
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
            course.CourseCategory = null;
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

        public async Task<IEnumerable<Course>> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _repository.GetAllAsync();

            return await Task.FromResult(_repository.Find(c =>
               c.Title.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase) ||
               c.Description.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<IEnumerable<Course>> Filter(CourseFilter filter)
        {
            var filteredCourses = await _repository.Filter(filter.Specifications);

            return filteredCourses;
        }

        public async Task<Stream> GetCsvContent()
        {
            var courses = await GetAllAsync();

            var sb = new StringBuilder();

            foreach (var course in courses)
            {
                sb.AppendLine($"{course.Title};{course.Description};{course.Price}");
            }

            return GenerateStreamFromString(sb.ToString());            
        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}