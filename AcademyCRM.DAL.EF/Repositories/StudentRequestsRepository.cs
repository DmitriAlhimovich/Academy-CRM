using System.Collections.Generic;
using System.Linq;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Repositories
{
    public class StudentRequestsRepository : BaseRepository<StudentRequest>
    {
        private readonly AcademyContext _context;

        public StudentRequestsRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<StudentRequest> GetAll()
        {
            return _context.StudentRequests
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToList();
        }
    }
}