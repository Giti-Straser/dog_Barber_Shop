using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICustomerBLL
    {
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerByUserNameAndPassword(string password, string userName);
        CustomerDTO GetCustomerByID(int id);
        void UpdateCustomer(CustomerDTO customer, int id);
        void AddCustomer(CustomerDTO c);
        void DeleteCustomer(CustomerDTO customer);
    }
}
