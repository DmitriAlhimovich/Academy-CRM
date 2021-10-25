using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.Core.Models;

namespace AcademyCRM.DAL
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
        Task<IEnumerable<Course>> GetCoursesByCategory(int categoryId, bool includeNested);
    }
}