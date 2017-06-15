using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CodeFirst
{
    public class SampleContext : DbContext
    {
        //public SampleContext() : base(ConfigurationManager.ConnectionStrings["MyShop"].ConnectionString)
        public SampleContext() : base()
        {
            Database.SetInitializer<SampleContext>(new DBInitializer());
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Database.Connection.ConnectionString = cs;
        }

        public SampleContext(string conStr): base (conStr)
        {

        }
        //static SampleContext()
        //{
        //    //Database.SetInitializer(new DBInitializer());
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
