using System.Data;
using System.Data.SqlClient;

namespace ServicioPruebaTecnica
{

    public class ConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}
