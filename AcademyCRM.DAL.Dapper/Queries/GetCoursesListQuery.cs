using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using MediatR;

namespace AcademyCRM.DAL.Dapper.Queries
{
    public record GetCoursesListQuery() : IRequest<IEnumerable<Course>>;

}
