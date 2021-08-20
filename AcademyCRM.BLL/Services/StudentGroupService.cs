using System.Collections.Generic;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IRepository<StudentGroup> _repository;
        private readonly IStudentRequestService _requestService;
        private readonly IStudentService _studentService;

        public StudentGroupService(IRepository<StudentGroup> repository, IStudentRequestService requestService, IStudentService studentService)
        {
            _repository = repository;
            _requestService = requestService;
            _studentService = studentService;
        }

        public IEnumerable<StudentGroup> GetAll()
        {
            return _repository.GetAll();
        }

        public StudentGroup GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Create(StudentGroup entity)
        {
            _repository.Create(entity);

            //add students from requests to group
            var studentsToGroup = _requestService.GetStudentsByCourse(entity.CourseId);
            foreach (var student in studentsToGroup)
            {
                student.GroupId = entity.Id;
                _studentService.Update(student);
            }
            //close requests
            var requests = _requestService.GetOpenRequestsByCourse(entity.CourseId);
            foreach (var request in requests)
            {
                request.Status = RequestStatus.Closed;
                _requestService.Update(request);
            }
        }

        public void Update(StudentGroup group)
        {
            _repository.Update(group);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}