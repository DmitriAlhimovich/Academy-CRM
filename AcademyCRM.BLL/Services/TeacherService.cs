using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Teacher GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Create(Teacher teacher)
        {
            _repository.Create(teacher);
        }

        public void Update(Teacher teacher)
        {
            _repository.Update(teacher);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}