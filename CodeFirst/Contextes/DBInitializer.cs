using System;
using System.Data.Entity;
using CodeFirst.Entities;

namespace CodeFirst.Contextes
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

            base.Seed(context);
        }
    }
}
