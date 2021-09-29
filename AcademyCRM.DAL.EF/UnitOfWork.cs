using AcademyCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICourseRepository _courses;

        public UnitOfWork(ICourseRepository courses)
        {
            _courses = courses;
        }

        public ICourseRepository Courses => _courses;
    }
}
