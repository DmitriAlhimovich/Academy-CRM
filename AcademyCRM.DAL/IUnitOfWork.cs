using AcademyCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.DAL
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }        
    }
}
