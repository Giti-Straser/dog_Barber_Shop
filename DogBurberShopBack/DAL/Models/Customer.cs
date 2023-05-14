using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Queues = new HashSet<Queue>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Queue> Queues { get; set; }
    }
}
