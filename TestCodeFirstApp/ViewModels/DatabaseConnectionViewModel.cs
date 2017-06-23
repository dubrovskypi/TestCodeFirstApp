using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CodeFirst;
using MVVMFrameWork;
using TestCodeFirstApp.Models;

namespace TestCodeFirstApp.ViewModels
{
    public class DatabaseConnectionViewModel: BaseViewModel
    {
        public ConnectionProperty Connection { get; set; }

        //    DataSource = "(LocalDB)\\MSSQLLocalDB", //server
        //    InitialCatalog = "MyTestDB", //DB name
        //    IntegratedSecurity = false,
        //    Pooling = false,
        //    PersistSecurityInfo = false,
        //    MultipleActiveResultSets = true,
        //    UserID = "Pasha",
        //    Password = "1234",

        private DelegateCommand _createDBCommand;
        public DelegateCommand CreateDBCommand
        {
            get
            {
                return _createDBCommand ??
                    (_createDBCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            DB.ConnectionString = Connection.GetConnectionString();
                            if (!DB.DatabaseExists(DB.ConnectionString))
                                DB.CreateDatabase();
                            //_repository = DB.CreateRepository();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
        }

        private DelegateCommand _testConnectionCommand;
        public DelegateCommand TestConnectionCommand
        {
            get
            {
                return _testConnectionCommand ??
                    (_testConnectionCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            var constr = Connection.GetConnectionString();
                            if (!DB.DatabaseExists(constr))
                                DB.CreateDatabase();
                            //_repository = DB.CreateRepository();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
        }

        public DatabaseConnectionViewModel(BaseViewModel parent):base (parent)
        {
            Connection = new ConnectionProperty();
        }
    }
}
