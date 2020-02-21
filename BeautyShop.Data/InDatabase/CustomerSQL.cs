using BeautyShop.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShop.Data.InDatabase
{
    public class CustomerSQL : ICustomer
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public CustomerSQL(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }
        public Customer Add(Customer customer)
        {
            var tempCustomer = beautyShopDbContext.Customers.Add(customer);
            return tempCustomer.Entity;
        }

        public int Commit()
        {
            return beautyShopDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            beautyShopDbContext.Customers.Remove(beautyShopDbContext.Customers.SingleOrDefault(x => x.Id == id));
        }

        public Customer GetCustomer(int id)
        {
            return beautyShopDbContext.Customers
                .Include(x=>x.Membership)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetCustomers(string name = null)
        {
            return beautyShopDbContext.Customers
                .Include(x=>x.Membership)
                .Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name)).ToList();
        }

        public Customer Update(Customer customer)
        {
            beautyShopDbContext.Entry(customer).State = EntityState.Modified;
            return customer;
        }
    }
}
