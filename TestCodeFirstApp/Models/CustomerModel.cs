using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using MVVMFrameWork;

namespace TestCodeFirstApp.Models
{
    public class CustomerModel : NotifyObject
    {

        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public byte[] Photo { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
