using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AcademyCRM.Core.Models;
using AcademyCRM.Core.Models.Filters;

namespace AcademyCRM.BLL.Services
{
    public interface ICourseService : IEntityService<Course>
    {
        Task<IEnumerable<Course>> Search(string search);
        Task<IEnumerable<Course>> Filter(CourseFilter filter);

        Task<Stream> GetCsvContent();
    }
}