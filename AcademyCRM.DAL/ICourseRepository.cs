using AcademyCRM.Core.Models;
using AcademyCRM.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.DAL
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> Filter(CourseFilter filter);
    }
}
