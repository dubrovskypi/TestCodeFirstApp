using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
