using System;
using System.Collections.Generic;
using System.Linq;
using AcademyCRM.BLL.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace AcademyCRM.DAL.Dapper.Repositories
{
    public class CoursesRepository : IRepository<Course>
    {
        private readonly IDbConnection dbConnection;



        public void Create(Course item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> Find(Func<Course, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Course Get(int id)
        {
            string sql = "SELECT * FROM Courses WHERE Id=@Id";

            using var connection =
                new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=AcademyCrmDB;Trusted_Connection=True;");

            return connection.QuerySingle<Course>(sql, new { Id = id });
        }

        public IEnumerable<Course> GetAll()
        {
            string sql = "SELECT * FROM Courses";

            using var connection =
                new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=AcademyCrmDB;Trusted_Connection=True;");
            return connection.Query<Course>(sql);
        }

        public void Update(Course item)
        {
            throw new NotImplementedException();
        }
    }
}