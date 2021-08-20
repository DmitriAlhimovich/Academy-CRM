using System.Collections.Generic;
using AcademyCRM.BLL.Models;

namespace AcademyCRM.BLL.Services
{
    public interface IStudentRequestService : IEntityService<StudentRequest>
    {
        IEnumerable<StudentRequest> GetOpenRequestsByCourse(int courseId);
        int GetOpenRequestsCountByCourse(int courseId);
        IEnumerable<Student> GetStudentsRequestedForCourse(int courseId);
        IEnumerable<StudentRequest> GetAllOpen();
    }
}