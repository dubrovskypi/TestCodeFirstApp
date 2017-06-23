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
        private CustomRepository _repository;

        private BaseViewModel _connectionVM;
        public BaseViewModel ConnectionVM
        {
            get { return _connectionVM; }
            set
            {
                if (_connectionVM != null) _connectionVM.Dispose();

                _connectionVM = value;
            }
        }

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
                            _repository.Create(NewCustomer);
                            _repository.Save();

                            CustomersCollection = new ObservableCollection<Customer>(_repository.GetItems());

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

                    }, () => _repository != null));
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
                            var customers = _repository.GetItems();
                            if (customers != null) CustomersCollection = new ObservableCollection<Customer>(customers);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }, () => _repository != null));
            }
        }

        //private DelegateCommand _createDBCommand;
        //public DelegateCommand CreateDBCommand
        //{
        //    get
        //    {
        //        return _createDBCommand ??
        //            (_createDBCommand = new DelegateCommand(() =>
        //            {
        //                try
        //                {
        //                    DB.TestConnection(DB.ConnectionString);

        //                    if (!DB.DatabaseExists(DB.ConnectionString))
        //                        DB.CreateDatabase();
        //                    _repository = DB.CreateRepository();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message, "Custom Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                }
        //            }));
        //    }
        //}
        #endregion

        public MainViewModel() : base()
        {
            NewCustomer = new Customer
            {
                Age = new Random().Next(20,90),
                CustomerId = Guid.NewGuid(),
                Email = "email",
                Name = "NameC",
                Orders = null,
                Photo = null
            };
            ConnectionVM = new DatabaseConnectionViewModel(this);
        }

        public override void Dispose()
        {
            ConnectionVM.Dispose();
            _repository.Dispose();
            base.Dispose();
        }
    }
}
