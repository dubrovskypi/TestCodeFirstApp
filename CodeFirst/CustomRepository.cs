using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        }

        public CustomRepository(SampleContext ctx)
        {
            this._db = ctx;
        }

        public IEnumerable<Customer> GetItems()
        {
            return _db.Customers;
        }

        public Customer GetItem(int id)
        {
            return _db.Customers.Find(id);
        }

        public void Create(Customer book)
        {
            _db.Customers.Add(book);
        }

        public void Update(Customer book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer book = _db.Customers.Find(id);
            if (book != null)
                _db.Customers.Remove(book);
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
