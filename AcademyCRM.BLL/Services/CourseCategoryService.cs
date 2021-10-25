using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL;

namespace AcademyCRM.BLL.Services
{
    public class CourseCategoryService : BaseEntityService<CourseCategory>, ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _repository;


        public CourseCategoryService(ICourseCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetCoursesWithHierarchy(int categoryId)
        {
            return await _repository.GetCoursesByCategory(categoryId, true);
        }
    }
}