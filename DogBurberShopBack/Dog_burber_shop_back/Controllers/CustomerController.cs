using BLL;
using DTO.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public CustomerController(ICustomerBLL contextCustomerBLL)
        {
            _contextCustomerBLL = contextCustomerBLL;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _contextCustomerBLL.GetAllCustomers();
            if (customers == null)
                return NoContent();
            return Ok(customers);
        }
        [Route("{userName}/{password}")]
        [HttpGet]
        public IActionResult GetCustomerByUserNameAndPassword(string userName,string password)
        {
            var customer = _contextCustomerBLL.GetCustomerByUserNameAndPassword(password,userName);
            if (customer == null)
                return NoContent();
            return Ok(customer);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCustomerByID(int id)
        {
            var customer = _contextCustomerBLL.GetCustomerByID(id);
            if (customer == null)
                return NoContent();
            return Ok(customer);
        }
        [HttpPut("{id}")]
        public void UpdateCustomer([FromBody] CustomerDTO customer, int id)
        {
            _contextCustomerBLL.UpdateCustomer(customer, id);
        }
        [HttpPost]
        public void AddCustomer([FromBody] CustomerDTO customer)
        {
             _contextCustomerBLL.AddCustomer(customer);
        }
        [HttpDelete]
        public void DeleteCustomer([FromBody] CustomerDTO customer)
        {
            _contextCustomerBLL.DeleteCustomer(customer);
        }
    }
}
