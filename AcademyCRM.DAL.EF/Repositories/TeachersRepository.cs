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
    public class TeachersRepository : IRepository<Teacher>
    {
        private readonly AcademyContext _context;

        public TeachersRepository(AcademyContext context)
        {
            _context = context;
        }

        public void Create(Teacher item)
        {
            _context.Teachers.Add(item);
        }

        public void Delete(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            if (teacher != null)
                _context.Teachers.Remove(teacher);
        }

        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return _context.Teachers.Where(predicate).ToList();
        }

        public Teacher Get(int id) => _context.Teachers.Find(id);

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public void Update(Teacher item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
