using BeautyShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShop.Data.InMemory
{
    public class CustomerInMemory : ICustomer
    {
        public List<Customer> Customers { get; set; }
        public CustomerInMemory()
        {
            Customers = new List<Customer>();
        }
        public Customer Add(Customer customer)
        {
            customer.Id = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
            Customers.Add(customer);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers(string name = null)
        {
            return Customers.Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().StartsWith(name.ToLower()));
        }

        public Customer GetCustomer(int id)
        {
            return Customers.SingleOrDefault(x => x.Id == id);
        }

        public Customer Update(Customer customer)
        {
            var tempCustomer = Customers.SingleOrDefault(x => x.Id == customer.Id);
            if (tempCustomer!=null)
            {
                tempCustomer.Name = customer.Name;
                tempCustomer.MembershipId = customer.MembershipId;
                tempCustomer.Membership = customer.Membership;
            }
            return tempCustomer;
        }

        public int Commit()
        {
            return 0;
        }

        public void Delete(int id)
        {
            Customers.Remove(Customers.SingleOrDefault(x => x.Id == id));
        }
    }
}
