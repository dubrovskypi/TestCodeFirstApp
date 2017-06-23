using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeFirstApp.Models
{
    public class ConnectionProperty
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ConnectionProperty()
        {
            ServerName = "(LocalDB)\\MSSQLLocalDB";
            DatabaseName = "MyTestDB";
            UserName = "Pasha";
            Password = "1234";
        }

        public string GetConnectionString()
        {
            var constr = new SqlConnectionStringBuilder()
            {
                DataSource = ServerName,
                InitialCatalog = DatabaseName,
                UserID = UserName,
                Password = Password
            }; 
            return constr.ConnectionString;
        }
    }
}
