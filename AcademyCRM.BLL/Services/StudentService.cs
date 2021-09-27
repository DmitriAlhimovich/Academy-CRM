using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Student GetById(int id)
        {
            return _repository.Get(id).EnsureNotNull();
        }

        public void Create(Student student)
        {
            _repository.Create(student);
        }

        public void Update(Student student)
        {
            _repository.Update(student);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}