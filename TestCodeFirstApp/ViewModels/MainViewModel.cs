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
using System.Configuration;
using System.Windows;
using CodeFirst.Contextes;
using CodeFirst.Entities;
using CodeFirst.Repositories;

namespace TestCodeFirstApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private CustomRepository repository;

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
                        try
                        {
                            repository.Create(NewCustomer);
                            repository.Save();

                            CustomersCollection = new ObservableCollection<Customer>(repository.GetItems());

                            //newCustomer
                            NewCustomer = new Customer
                            {
                                Age = new Random().Next(20, 90),
                                CustomerId = Guid.NewGuid(),
                                Email = "email",
                                Name = "NameC",
                                Orders = null,
                                Photo = null
                            };

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }, () => repository != null));
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
                        try
                        {
                            var customers = repository.GetItems();
                            if (customers != null) CustomersCollection = new ObservableCollection<Customer>(customers);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }, () => repository != null));
            }
        }

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
                            //repository = new CustomRepository();
                            //DB.CreateDatabase();
                            repository = new CustomRepository(new SampleContext(DB.ConnectionString));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }));
            }
        }
        #endregion

        public MainViewModel() : base()
        {
            //repository = new CustomRepository();

            NewCustomer = new Customer
            {
                Age = new Random().Next(20,90),
                CustomerId = Guid.NewGuid(),
                Email = "email",
                Name = "NameC",
                Orders = null,
                Photo = null
            };
        }

        public override void Dispose()
        {
            repository.Dispose();
            base.Dispose();
        }
    }
}
