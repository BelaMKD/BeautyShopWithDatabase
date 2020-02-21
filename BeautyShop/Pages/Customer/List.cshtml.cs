using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShop.Core;
using BeautyShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop
{
    public class ListModel : PageModel
    {
        private readonly ICustomer customerData;
        [TempData]
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public ListModel(ICustomer customerData)
        {
            this.customerData = customerData;
        }
        public void OnGet()
        {
            Customers = customerData.GetCustomers(SearchName);
        }
    }
}