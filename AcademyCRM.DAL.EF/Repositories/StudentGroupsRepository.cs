using AcademyCRM.Core.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            StudentGroup group = _context.StudentGroups.Find(id);
            if (group != null)
                _context.StudentGroups.Remove(group);
        }

        public async Task<IEnumerable<StudentGroup>> GetAllAsync()
        {
            return await _context.StudentGroups.Include(g => g.Teacher).ToListAsync();
        }

        public IEnumerable<StudentGroup> Find(Func<StudentGroup, bool> predicate)
        {
            return _context.StudentGroups.Where(predicate).ToList();
        }

        public StudentGroup Get(int id) => _context.StudentGroups.Include(g => g.Students).First(g => g.Id == id);

        public IEnumerable<StudentGroup> GetAll()
        {
            var query = _context.StudentGroups.Include(g => g.Students);

            var sql = query.ToQueryString();

            return query.ToList();
        }

        public void Update(StudentGroup item)
        {
            //_context.Entry(item).State = EntityState.Modified;
            var existingItem = _context.StudentGroups.Find(item.Id);
            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }
    }
}
