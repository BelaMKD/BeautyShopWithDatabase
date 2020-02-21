using BeautyShop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Data
{
    public interface ICustomer
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers(string name = null);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        void Delete(int id);
        int Commit();
    }
}
