using BLL;
using DTO.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_burber_shop_back.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerBLL _contextCustomerBLL;
        ILogger<CustomerController> _logger;
        public CustomerController(ICustomerBLL contextCustomerBLL,ILogger<CustomerController> logger)
        {
            _contextCustomerBLL = contextCustomerBLL;
            _logger = logger;
        }
        [Route("{userName}/{password}")]
        [HttpGet]
        public IActionResult GetCustomerByUserNameAndPassword(string userName,string password)
        {
            try
            {
                _logger.LogInformation("start GetCustomerByUserNameAndPassword");
                var customer = _contextCustomerBLL.GetCustomerByUserNameAndPassword(password, userName);
                if (customer == null)
                    return NoContent();
                return Ok(customer);
            }
            catch(Exception ex)
            {
                _logger.LogError($" error in GetCustomerByUserNameAndPassword {ex.Message}, {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                _logger.LogInformation("start AddCustomer");
                _contextCustomerBLL.AddCustomer(customer);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError($" error in AddCustomer {ex.Message}, {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
    }
}
