using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShop.Core;
using BeautyShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShop
{
    public class EditModel : PageModel
    {
        private readonly ICustomer customerData;
        private readonly IMembrship membrshipData;

        [BindProperty]
        public Customer Customer { get; set; }
        public List<SelectListItem> MembershipTypes { get; set; }
        public EditModel(ICustomer customerData, IMembrship membrshipData)
        {
            this.customerData = customerData;
            this.membrshipData = membrshipData;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Customer = customerData.GetCustomer(id.Value);
                if (Customer == null)
                {
                    return RedirectToPage("./List");
                }
            }
            else
            {
                Customer = new Customer();
            }
            MembershipTypes = membrshipData.GetMembrships().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Type
            }).ToList();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var membership = membrshipData.GetMembership(Customer.MembershipId);
                Customer.Membership = membership;
                if (Customer.Id != 0)
                {
                    Customer = customerData.Update(Customer);
                    TempData["Message"] = "Customer is updated !";
                }
                else
                {
                    Customer = customerData.Add(Customer);
                    TempData["Message"] = "New Customer is added !";
                }
                customerData.Commit();
                return RedirectToPage("./List");
            }
            MembershipTypes = membrshipData.GetMembrships().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Type
            }).ToList();
            return Page();
        } 
    }
}