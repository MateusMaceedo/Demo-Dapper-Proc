using Dapper;
using StudentRecordManagementApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace StudentRecordManagementApp.Services
{
    public class StudentServices : IStudentService
    {
        private readonly IConfiguration _configuration;

        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DbConnection");
            ProviderName = "System.Data.SqlClient"; 
        }

        public string? ConnectionString { get; set; }
        public string? ProviderName { get; set; }

        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        public string InsertStudent(Students model)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var student = dbConnection.Query<Students>("InsertStudentRecord", model, commandType: CommandType.StoredProcedure).ToList();
                dbConnection.Close();
            }

            return "";
        }

        public List<Students> GetStudentsList()
        {
            List<Students> result = new();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<Students>("InsertStudentList", commandType: CommandType.StoredProcedure).ToList();

                    dbConnection.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return result;
            }
        }
    }

    public interface IStudentService
    {
        public string InsertStudent(Students model);
        public List<Students> GetStudentsList();
    }
}
