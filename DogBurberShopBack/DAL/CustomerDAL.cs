using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL:ICustomerDAL
    {
        Dogs_burber_shopContext _dbContext;
        public CustomerDAL(Dogs_burber_shopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }
        public Customer GetCustomerByUserNameAndPassword(string password, string userName)
        {
            var currentCustomer = _dbContext.Customers.SingleOrDefault(c => c.Password == password && c.UserName == userName);
            return currentCustomer;
        }
        public Customer GetCustomerByID(int id)
        {
            var currentCustomer = _dbContext.Customers.SingleOrDefault(c => c.CustomerId == id);
            return currentCustomer;
        }
        public void UpdateCustomer(Customer customer, int id)
        {
            var currentC =  _dbContext.Customers.SingleOrDefault(i => i.CustomerId == id);
            currentC.FirstName = customer.FirstName;
            currentC.Password = customer.Password;
            currentC.UserName = customer.UserName;
            _dbContext.Customers.Update(currentC);
             _dbContext.SaveChanges();
        }
        public void AddCustomer(Customer c)
        {
            _dbContext.Customers.Add(c);
            _dbContext.SaveChanges();
        }
        public void DeleteCustomer(Customer c)
        {
            _dbContext.Customers.Remove(c);
            _dbContext.SaveChanges();
        }
    }
}
