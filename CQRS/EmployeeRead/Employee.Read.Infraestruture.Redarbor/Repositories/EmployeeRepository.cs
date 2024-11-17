
using Employee.Read.Domain.Redarbor.Entities;
using Employee.Read.Domain.Redarbor.Interfaces;
using Employee.Read.Infraestruture.Redarbor.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Employee.Read.Infraestruture.Redarbor.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbQueryProvider _queryProvider;
        private readonly string _connectionString;
        private readonly IDbConnection Connection;

        public EmployeeRepository(IConfiguration configuration, IDbQueryProvider queryProvider)         
        {
            _queryProvider = queryProvider;
            _connectionString = configuration["DbEmployeesConnection"].ToString();
            Connection = new SqlConnection(_connectionString);
        }

        public async Task<EEmployee> GetEmployeeByIdAsync(long employeeId)
        {
            var sql = _queryProvider.GetEmployeeByIdQuery;
            using var connection = Connection;
            return await connection.QueryFirstOrDefaultAsync<EEmployee>(sql, new { Id = employeeId });
        }

        public async Task<IEnumerable<EEmployee>> GetEmployeesAsync()
        {
            var sql = _queryProvider.GetEmployeesQuery;
            using var connection = Connection;
            return await connection.QueryAsync<EEmployee>(sql);
        }
    }
}
