using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICustomerDAL
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerByUserNameAndPassword(string password , string userName);
        Customer GetCustomerByID(int id);
        void UpdateCustomer(Customer customer, int id);
        void AddCustomer(Customer c);
        void DeleteCustomer(Customer c);
    }
}
