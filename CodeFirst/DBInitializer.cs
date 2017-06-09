using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class DBInitializer: DropCreateDatabaseAlways<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            var defCustomer = new Customer
            {
                Age = 99,
                CustomerId = Guid.NewGuid(),
                Email = "def@mail.com",
                Name = "DefName",
                Orders = null,
                Photo = null
            };
            context.Customers.Add(defCustomer);
            context.SaveChanges();
        }
    }
}
