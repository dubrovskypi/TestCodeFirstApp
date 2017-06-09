using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public static class DB
    {
        private static SqlConnectionStringBuilder _CONNECTIONSTRING = new SqlConnectionStringBuilder()
        {
            DataSource = "(LocalDB)\\MSSQLLocalDB",
            InitialCatalog = "MyTestDB",
            //IntegratedSecurity = true,
            //Pooling = false
        };

        public static string ConnectionString
        {
            get { return _CONNECTIONSTRING.ConnectionString; }
            set { _CONNECTIONSTRING = new SqlConnectionStringBuilder(value); }
        }

        private static SqlConnection _connection;
        public static SqlConnection Connection
        {
            get
            {
                return _connection ?? (_connection = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                });
            }
        }

        public static void CreateDatabase()
        {
            var init = new DBInitializer();
            init.InitializeDatabase();
        }
    }
}
