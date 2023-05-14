using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
    public class QueueDAL:IQueueDAL
    {
        Dogs_burber_shopContext _dbContext;
        public QueueDAL(Dogs_burber_shopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Queue> GetAllQueues()
        {
            return _dbContext.Queues.ToList();
        }
        public void UpdateQueue(Queue queue, int id)
        {
            var currentQ = _dbContext.Queues.SingleOrDefault(i => i.QueueId == id);
            currentQ.QueueTime = queue.QueueTime;
            _dbContext.Queues.Update(currentQ);
            _dbContext.SaveChanges();
        }
        public List<TodayQueue> GetQueue()
        {
            List<TodayQueue> queues = new List<TodayQueue>();
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "GetQueue";
                command.CommandType = CommandType.StoredProcedure;

                _dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TodayQueue queue = new TodayQueue
                        {
                            QueueId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            QueueTime = reader.GetDateTime(2),
                            RegistrationTime = reader.GetDateTime(3),
                            CustomerId = reader.GetInt32(4),
                        };
                        queues.Add(queue);
                    }
                }
            }
            return queues;

        }
        public void AddQueue(Queue q)
        {
            q.RegistrationTime = DateTime.Now;
            _dbContext.Queues.Add(q);
            _dbContext.SaveChanges();
        }
        public void DeleteQueue(Queue q)
        {
            _dbContext.Queues.Remove(q);
            _dbContext.SaveChanges();
        }
    }
}
