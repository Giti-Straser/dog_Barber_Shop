using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QueueBLL:IQueueBLL
    {
        IMapper iMapper;
        private IQueueDAL _contextQueueDl;

        public QueueBLL(IQueueDAL contextQueueDl)
        {
            _contextQueueDl = contextQueueDl;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            iMapper = config.CreateMapper();
        }
        public List<QueueDTO> GetAllQueues()
        {
            List<Queue> queues = _contextQueueDl.GetAllQueues();
            List<QueueDTO> listQueues = iMapper.Map<List<Queue>, List<QueueDTO>>(queues);
            return listQueues;
        }
        public List<TodayQueue> GetQueue()
        {
            List<TodayQueue> queues = _contextQueueDl.GetQueue();
            return queues;
        }
        public void UpdateQueue(QueueDTO queue, int id)
        {
            Queue q = iMapper.Map<QueueDTO, Queue>(queue);
            _contextQueueDl.UpdateQueue(q, id);
        }
        public void AddQueue(QueueDTO q)
        {
            var currentQueue = iMapper.Map<QueueDTO, Queue>(q);
            _contextQueueDl.AddQueue(currentQueue);
        }
        public void DeleteQueue(QueueDTO queue)
        {
            Queue q = iMapper.Map<QueueDTO, Queue>(queue);
            _contextQueueDl.DeleteQueue(q);
        }
    }
}
