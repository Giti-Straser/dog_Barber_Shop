using BLL;
using DAL;
using DTO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        ILogger<QueueController> _logger;
        public QueueController(IQueueBLL contextQueueBLL, ILogger<QueueController> logger)
        {
            _contextQueueBLL = contextQueueBLL;
            _logger = logger;
        }
        [Route("today")]
        [HttpGet]
        public IActionResult GetQueue()
        {
            try
            {
                _logger.LogInformation("start GetQueue");
                var queue = _contextQueueBLL.GetQueue();
                if (queue == null)
                    return NoContent();
                return Ok(queue);
            }
            catch(Exception ex)
            {
                _logger.LogError($"error in GetQueue {ex.Message}, {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);

            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateQueue([FromBody] QueueDTO Queue, int id)
        {
            try
            {
                _logger.LogInformation("start UpdateQueue");
                _contextQueueBLL.UpdateQueue(Queue, id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError($"error in UpdateQueue {ex.Message}, {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddQueue([FromBody] QueueDTO Queue)
        {
            try
            {
                _logger.LogInformation("start AddQueue");
                _contextQueueBLL.AddQueue(Queue);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in AddQueue {ex.Message}, {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteQueue([FromBody] QueueDTO Queue)
        {
            try
            {
                _logger.LogInformation("start DeleteQueue");
                _contextQueueBLL.DeleteQueue(Queue);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in DeleteQueue {ex.Message}, {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
