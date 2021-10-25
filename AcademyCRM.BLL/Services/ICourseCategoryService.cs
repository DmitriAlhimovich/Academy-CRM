using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AcademyCRM.Core.Filters;
using AcademyCRM.Core.Models;

namespace AcademyCRM.BLL.Services
{
    public interface ICourseCategoryService : IEntityService<CourseCategory>
    {
        Task<IEnumerable<Course>> GetCoursesWithHierarchy(int categoryId);
    }
}