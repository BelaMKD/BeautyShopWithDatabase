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
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerData;
        [BindProperty]
        public Customer Customer { get; set; }
        public DeleteModel(ICustomer customerData)
        {
            this.customerData = customerData;
        }
        public IActionResult OnGet(int id)
        {
            Customer = customerData.GetCustomer(id);
            if (Customer==null)
            {
                return RedirectToPage("./List");
            }
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            customerData.Delete(id);
            customerData.Commit();
            TempData["Message"] = "The Object is deleted!";
            return RedirectToPage("./list");
        }
    }
}