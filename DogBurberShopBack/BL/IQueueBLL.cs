using DAL.Models;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IQueueBLL
    {
        List<QueueDTO> GetAllQueues();
        List<TodayQueue> GetQueue();
        void UpdateQueue(QueueDTO queue, int id);
        void AddQueue(QueueDTO q);
        void DeleteQueue(QueueDTO queue);
    }
}
