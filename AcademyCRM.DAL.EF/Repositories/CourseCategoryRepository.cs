using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Repositories
{
    public class CourseCategoryRepository : BaseRepository<CourseCategory>, ICourseCategoryRepository
    {
        private readonly AcademyContext _context;

        public CourseCategoryRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategory(int categoryId, bool includeNested = false)
        {
            var query = _context.Courses.Where(c => c.Categories.Any(cat => cat.Id == categoryId));

            if (!includeNested)
                return await query.ToListAsync();

            var childCategoryIds = await _context.CourseCategories.Where(c => c.ParentId == categoryId).Select(c => c.Id).ToListAsync();

            foreach (var childCategoryId in childCategoryIds)
            {
                query = query.Union(_context.Courses.Where(c => c.Categories.Any(cat => cat.Id == childCategoryId)));
            }


            //var category = _context.CourseCategories.Single(c => c.Id == categoryId);
            //while (category.Parent is not null)
            //{
            //    category = category.Parent;
            //    query = query.Where(c => c.Categories.Any(cat => cat.Id == categoryId));
            //} 

            return await query.ToListAsync();
        }
    }
}