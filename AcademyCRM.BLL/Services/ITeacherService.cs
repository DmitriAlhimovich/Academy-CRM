using System.Collections.Generic;
using AcademyCRM.BLL.Models;

namespace AcademyCRM.BLL.Services
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Update(Teacher teacher);
    }
}