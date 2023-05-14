using BLL;
using DAL;
using DTO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_burber_shop_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        IQueueBLL _contextQueueBLL;
        public QueueController(IQueueBLL contextQueuerBLL)
        {
            _contextQueueBLL = contextQueuerBLL;
        }
        [HttpGet]
        public IActionResult GetAllQueues()
        {
            var Queues = _contextQueueBLL.GetAllQueues();
            if (Queues == null)
                return NoContent();
            return Ok(Queues);
        }
        [Route("today")]
        [HttpGet]
        public IActionResult GetTodayQueue()
        {
            var queue = _contextQueueBLL.GetTodayQueue();
            if (queue == null)
                return NoContent();
            return Ok(queue);
        }
        [HttpPut("{id}")]
        public void UpdateQueue([FromBody] QueueDTO Queue, int id)
        {
            _contextQueueBLL.UpdateQueue(Queue, id);
        }
        [HttpPost]
        public void AddQueue([FromBody] QueueDTO Queue)
        {
            _contextQueueBLL.AddQueue(Queue);
        }
        [HttpDelete]
        public void DeleteQueue([FromBody] QueueDTO Queue)
        {
            _contextQueueBLL.DeleteQueue(Queue);
        }
    }
}
