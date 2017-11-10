using System.Data.SqlClient;

namespace OWApi
{
    public class ConnectionCreator
    {
        public SqlConnection CreateConnection()
        {
            const string connStr =
                "Server=tcp:owapi.database.windows.net,1433;Initial Catalog=OWAPI;Persist Security Info=False;User ID=thomas.rice;Password=Jasper131;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            return new SqlConnection(connStr);
        }
    }
}