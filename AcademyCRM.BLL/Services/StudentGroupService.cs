using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IRepository<StudentGroup> _repository;

        public StudentGroupService(IRepository<StudentGroup> repository)
        {
            _repository = repository;
        }

        public IEnumerable<StudentGroup> GetAll()
        {
            return _repository.GetAll();
        }

        public StudentGroup GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Update(StudentGroup group)
        {
            _repository.Update(group);
        }
    }
}