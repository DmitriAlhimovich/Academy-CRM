using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AcademyCRM.DAL.Dapper
{
    public class DbConnectionService : IDbConnectionService
    {
        public SqlConnection SqlConnection { get; init; }
        public DbConnectionService(IConfiguration configuration)
        {
            SqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    public interface IDbConnectionService
    {
        SqlConnection SqlConnection { get; init; }
    }
}
