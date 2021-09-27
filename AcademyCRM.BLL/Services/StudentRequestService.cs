using System.Collections.Generic;
using System.Linq;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class StudentRequestService : BaseEntityService<StudentRequest>, IStudentRequestService
    {
        private readonly IRepository<StudentRequest> _repository;

        public StudentRequestService(IRepository<StudentRequest> repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<StudentRequest> GetAllOpen()
        {
            return _repository.GetAll().Where(r => r.Status == RequestStatus.Open);
        }

        public IEnumerable<StudentRequest> GetOpenRequestsByCourse(int courseId)
        {
            return _repository.GetAll().Where(r => r.CourseId == courseId && r.Status == RequestStatus.Open);
        }

        public int GetOpenRequestsCountByCourse(int courseId)
        {
            return _repository.Find(r => r.CourseId == courseId && r.Status == RequestStatus.Open).Count();
        }

        public IEnumerable<Student> GetStudentsRequestedForCourse(int courseId)
        {
            return _repository.GetAll().Where(r => r.Status == RequestStatus.Open && r.CourseId == courseId).Select(r => r.Student).Distinct();
        }

        
    }
}