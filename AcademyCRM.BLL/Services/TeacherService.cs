using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public Teacher GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Teacher teacher)
        {
            _repository.Update(teacher);
        }
    }
}