using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    class TodayQueueDTO
    {
        public int QueueId { get; set; }
        public DateTime? QueueTime { get; set; }
        public DateTime? RegistrationTime { get; set; }
        public int? CustomerId { get; set; }
        public string? FirstName { get; set; }
    }
}
