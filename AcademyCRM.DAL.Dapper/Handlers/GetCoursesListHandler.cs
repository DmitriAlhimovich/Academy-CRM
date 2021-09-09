using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL.Dapper.Queries;
using Dapper;
using MediatR;

namespace AcademyCRM.DAL.Dapper.Handlers
{
    public class GetCoursesListHandler : IRequestHandler<GetCoursesListQuery, IEnumerable<Course>>
    {
        private readonly IDbConnectionService _dbConnection;

        public GetCoursesListHandler(IDbConnectionService dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<Course>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
        {
            string sql = "SELECT * FROM Courses";

            return _dbConnection.SqlConnection.QueryAsync<Course>(sql);
        }
    }
}
