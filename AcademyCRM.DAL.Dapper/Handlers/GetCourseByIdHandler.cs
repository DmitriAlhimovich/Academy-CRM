using System.Threading;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL.Dapper.Queries;
using Dapper;
using MediatR;

namespace AcademyCRM.DAL.Dapper.Handlers
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly IDbConnectionService _dbConnection;

        public GetCourseByIdHandler(IDbConnectionService dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            string sql = "SELECT * FROM Courses WHERE Id=@Id";

            return _dbConnection.SqlConnection.QuerySingleAsync<Course>(sql, new { Id = request.Id });
        }
    }
}
