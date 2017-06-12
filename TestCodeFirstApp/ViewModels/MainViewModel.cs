using MVVMFrameWork;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestCodeFirstApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestCodeFirstApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private Customer _newCustomer;
        public Customer NewCustomer
        {
            get { return _newCustomer; }
            set
            {
                _newCustomer = value; 
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Customer> _customersCollection;
        public ObservableCollection<Customer> CustomersCollection
        {
            get { return _customersCollection; }
            set
            {
                _customersCollection = value; 
                OnPropertyChanged();
            }
        }

        #region Comands
        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new DelegateCommand(() =>
                    {

                        //Создать объект контекста
                       var context = new SampleContext();
                        

                        // Вставить данные в таблицу Customers с помощью LINQ
                        context.Customers.Add(NewCustomer);

                        // Сохранить изменения в БД
                        context.SaveChanges();
                    }));
            }
        }

        private DelegateCommand _loadCommand;
        public DelegateCommand LoadCommand
        {
            get
            {
                return _loadCommand ??
                    (_loadCommand = new DelegateCommand(() =>
                    {
                        CustomersCollection = new ObservableCollection<Customer>();
                        DB.CreateDatabase();
                        //Создать объект контекста
                        using (var context = new SampleContext())
                        {
                            context.Customers.Load();
                            CustomersCollection = context.Customers.Local;
                        }
                    }));
            }
        }
        #endregion

        public MainViewModel() : base()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleContext>());
            var _CONNECTIONSTRING = new SqlConnectionStringBuilder();
            var cs =_CONNECTIONSTRING.ConnectionString;
            NewCustomer = new Customer
            {
                Age = 99,
                CustomerId = Guid.NewGuid(),
                Email = "email",
                Name = "NameC",
                Orders = null,
                Photo = null
            };
        }

        //public MainViewModel(BaseViewModel parent, string title = null):base(parent,title)
        //{
        //    NewCustomer = new Customer
        //    {
        //        Age = 10,
        //        CustomerId = 20,
        //        Email = "email",
        //        Name = "NameC",
        //        Orders = null,
        //        Photo = null
        //    };
        //}

        
    }
}
