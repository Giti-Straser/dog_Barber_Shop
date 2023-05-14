using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using DTO;
using DTO.Model;

namespace BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        IMapper iMapper;
        private ICustomerDAL _contextCustomerDl;

        public CustomerBLL(ICustomerDAL contextCustomerDl)
        {
            _contextCustomerDl = contextCustomerDl;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            iMapper = config.CreateMapper();
        }
        public List<CustomerDTO> GetAllCustomers()
        {
            List<Customer> customers = _contextCustomerDl.GetAllCustomers();
            List<CustomerDTO> listCustomers = iMapper.Map<List<Customer>, List<CustomerDTO>>(customers);
            return listCustomers;
        }
        public CustomerDTO GetCustomerByUserNameAndPassword(string password, string userName)
        {
            var currentCustomer = _contextCustomerDl.GetCustomerByUserNameAndPassword(password,userName);
            CustomerDTO c = iMapper.Map<Customer, CustomerDTO>(currentCustomer);
            return c;
        }
        public CustomerDTO GetCustomerByID(int id)
        {
            var currentCustomer = _contextCustomerDl.GetCustomerByID(id);
            CustomerDTO c = iMapper.Map<Customer, CustomerDTO>(currentCustomer);
            return c;
        }
        public void UpdateCustomer(CustomerDTO customer, int id)
        {
            Customer c = iMapper.Map<CustomerDTO, Customer>(customer);
            _contextCustomerDl.UpdateCustomer(c, id);
        }
        public void AddCustomer(CustomerDTO c)
        {
            var currentCustomer = iMapper.Map<CustomerDTO, Customer>(c);
            _contextCustomerDl.AddCustomer(currentCustomer);
        }
        public void DeleteCustomer(CustomerDTO customer)
        {
            Customer c = iMapper.Map<CustomerDTO, Customer>(customer);
            _contextCustomerDl.DeleteCustomer(c);
        }
    }
}
