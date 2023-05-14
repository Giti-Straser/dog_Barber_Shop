using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public interface IQueueDAL
    {
        List<Queue> GetAllQueues();
        void UpdateQueue(Queue queue, int id);
        void AddQueue(Queue q);
        void DeleteQueue(Queue q);
        List<TodayQueue> GetQueue();

    }
}
