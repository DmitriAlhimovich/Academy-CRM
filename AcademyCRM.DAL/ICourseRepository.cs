using AcademyCRM.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.Core.Filters;

namespace AcademyCRM.DAL
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> Filter(CourseFilter filter);

        Task<IEnumerable<Course>> Filter(IEnumerable<ISpecification<Course>> specifications);
    }
}
