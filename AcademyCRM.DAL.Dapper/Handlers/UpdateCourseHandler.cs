using System.Threading;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using AcademyCRM.DAL.Dapper.Queries;
using Dapper;
using MediatR;

namespace AcademyCRM.DAL.Dapper.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, int>
    {
        private readonly IDbConnectionService _dbConnection;

        public UpdateCourseHandler(IDbConnectionService dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            string sql = $"UPDATE Courses SET {nameof(Course.Title)}=@Title, {nameof(Course.Description)}=@Description WHERE Id=@Id";

            return await _dbConnection.SqlConnection.ExecuteAsync(sql,
                new { Id = request.Course.Id, Title = request.Course.Title, Description = request.Course.Description });
        }
    }
}
