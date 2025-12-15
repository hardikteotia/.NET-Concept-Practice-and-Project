using Microsoft.Data.SqlClient;

namespace SqlServerConnectionLib
{
    public class SqlServerConnection
    {
        public SqlConnection provideConnection()
        {

            //first we create connection string 
            /*A connection string is just: The address + credentials + settings .NET needs to talk to your database.*/

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                                      "Initial Catalog=IACSDDB;" +
                                      "Integrated Security=True;" +
                                      "Encrypt=True";

            //now we create the connection object
            SqlConnection dbConnection = new SqlConnection(connectionString);

            //after creating the connection we will open the connection
            //dbConnection.Open();

            return dbConnection;
        }
    }
}
