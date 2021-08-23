using System.Collections.Generic;
using System.Linq;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Repositories
{
    public class CoursesRepository : BaseRepository<Course>
    {
        private readonly AcademyContext _context;

        public CoursesRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Topic)
                .ToList();
        }
    }
}