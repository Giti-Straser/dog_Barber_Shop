using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TodayQueue
    {
        public int QueueId { get; set; }
        public DateTime? QueueTime { get; set; }
        public DateTime? RegistrationTime { get; set; }
        public int? CustomerId { get; set; }
        public string? FirstName { get; set; }
    }
}
