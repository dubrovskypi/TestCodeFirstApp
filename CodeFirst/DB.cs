using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Contextes;

namespace CodeFirst
{
    public static class DB
    {
        private static SqlConnectionStringBuilder _connStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "(LocalDB)\\MSSQLLocalDB", //server
            InitialCatalog = "MyTestDB", //DB name
            IntegratedSecurity = true,
            Pooling = false,
            PersistSecurityInfo = false,
            MultipleActiveResultSets = true,
            ApplicationName = "EntityFramework",
            //UserID = "AxisG",
            //Password = "POLIapplehouse93",

        };

        public static string ConnectionString
        {
            get { return _connStringBuilder.ConnectionString; }
            set { _connStringBuilder = new SqlConnectionStringBuilder(value); }
        }

        //private static SqlConnection _connection;
        //public static SqlConnection Connection
        //{
        //    get
        //    {
        //        return _connection ?? (_connection = new SqlConnection()
        //        {
        //            ConnectionString = ConnectionString
        //        });
        //    }
        //}

        public static void CreateDatabase()
        {
            try
            {
                using (var context = new SampleContext(ConnectionString))
                {
                    var init = new DBInitializer();
                    init.InitializeDatabase(context);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }




    }
}
