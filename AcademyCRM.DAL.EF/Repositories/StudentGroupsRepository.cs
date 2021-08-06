using AcademyCRM.BLL.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.DAL.EF.Repositories
{
    public class StudentGroupsRepository : IRepository<StudentGroup>
    {
        private readonly AcademyContext _context;

        public StudentGroupsRepository(AcademyContext context)
        {
            _context = context;
        }

        public void Create(StudentGroup item)
        {
            _context.StudentGroups.Add(item);
        }

        public void Delete(int id)
        {
            StudentGroup group = _context.StudentGroups.Find(id);
            if (group != null)
                _context.StudentGroups.Remove(group);
        }

        public IEnumerable<StudentGroup> Find(Func<StudentGroup, bool> predicate)
        {
            return _context.StudentGroups.Where(predicate).ToList();
        }

        public StudentGroup Get(int id) => _context.StudentGroups.Find(id);

        public IEnumerable<StudentGroup> GetAll()
        {
            return _context.StudentGroups.Include(g => g.Teacher).ToList();
        }

        public void Update(StudentGroup item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
