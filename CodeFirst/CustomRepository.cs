using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CustomRepository : IRepository<Customer>
    {
        private SampleContext _db;

        public CustomRepository()
        {
            this._db = new SampleContext();
            InitDB();
        }

        public CustomRepository(SampleContext ctx)
        {
            this._db = ctx;
            InitDB();
        }

        private void InitDB()
        {
            try
            {
                var init = new DBInitializer();
                init.InitializeDatabase(this._db);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public IEnumerable<Customer> GetItems()
        {
            return _db.Customers;
        }

        public Customer GetItem(int id)
        {
            return _db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            _db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer customer = _db.Customers.Find(id);
            if (customer != null)
                _db.Customers.Remove(customer);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
}
}
