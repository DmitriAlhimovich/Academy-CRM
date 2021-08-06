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
    public class StudentsRepository : IRepository<Student>
    {
        private readonly AcademyContext _context;

        public StudentsRepository(AcademyContext context)
        {
            _context = context;
        }


        public void Create(Student item)
        {
            _context.Students.Add(item);
        }

        public void Delete(int id)
        {
            Student student = _context.Students.Find(id);
            if (student != null)
                _context.Students.Remove(student);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return _context.Students.AsNoTracking().Where(predicate).ToList();
        }

        public Student Get(int id) => _context.Students.Find(id);

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.AsNoTracking()
                .Include(s => s.Group)
                .ToList();
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
