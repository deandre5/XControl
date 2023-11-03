using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace poryecto_finanzas
{
    public class MySqlConfig
    {
        public string ConnectionString { get; set; }
        private MySqlConnection connection;


        public MySqlConfig(string connectionString) 
        {
            ConnectionString = connectionString;
        }



        public MySqlConnection GetConnection()
        {

            if (connection == null)
            {
                connection = new MySqlConnection(ConnectionString);
            }

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            
            return connection;
        }

    }
}
