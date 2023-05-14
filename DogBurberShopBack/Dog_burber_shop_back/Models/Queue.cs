using System;
using System.Collections.Generic;

#nullable disable

namespace DogBurberShopBack.Models
{
    public partial class Queue
    {
        public int QueueId { get; set; }
        public DateTime? QueueTime { get; set; }
        public DateTime? RegistrationTime { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
