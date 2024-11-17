
namespace Employee.Read.Infraestruture.Redarbor.Configuration
{
    public interface IDbQueryProvider
    {
        string GetEmployeesQuery { get; }
        string GetEmployeeByIdQuery { get; }
    }

    public class DbQueryProvider : IDbQueryProvider
    {
        string sqlFilesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "SqlFiles");

        public string GetEmployeesQuery => File.ReadAllText(Path.Combine(sqlFilesPath, "GetEmployeesQuery.sql"));

        public string GetEmployeeByIdQuery => File.ReadAllText(Path.Combine(sqlFilesPath, "GetEmployeeByIdQuery.sql"));
    }
}
