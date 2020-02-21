using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShop.Core;
using BeautyShop.Data;
using BeautyShop.Data.InDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShop
{
    public class ShopModel : PageModel
    {
        private readonly IVisit visitData;
        private readonly ICustomer customerData;
        private readonly VisitTP visitTP;

        [BindProperty]
        public Visit Visit { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public string Message { get; set; }
        public ShopModel(IVisit visitData, ICustomer customerData, VisitTP visitTP)
        {
            this.visitData = visitData;
            this.customerData = customerData;
            this.visitTP = visitTP;
        }
        public void OnGet()
        {
            Visit = new Visit();
            Customers = customerData.GetCustomers().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        public void OnPostBuy(double? priceProduct, double? priceService)
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomer(Visit.CustomerId.Value);
                Visit.Customer = customer;
                if (priceProduct > 0 && priceProduct.HasValue)
                {
                    ShopItem shopItem = new ShopItem
                    {
                        ItemType = ItemType.Product,
                        Price = priceProduct.Value
                    };
                    Visit.ShopItems.Add(shopItem);
                }
                if (priceService > 0 && priceService.HasValue)
                {
                    ShopItem shopItem = new ShopItem
                    {
                        ItemType = ItemType.Service,
                        Price = priceService.Value
                    };
                    Visit.ShopItems.Add(shopItem);
                }
            }
            Message = Visit.CustomerId == null ? "No customer selected!" : $"Total pay: {visitTP.TotalPrice(Visit)}";
            Customers = customerData.GetCustomers().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
                var customer = customerData.GetCustomer(Visit.CustomerId.Value);
                Visit.Customer = customer;
                if (visitTP.TotalPrice(Visit)==0)
                {
                    TempData["Message2"] = "Please buy something next time !";
                    return RedirectToPage("./List");
                }
                Visit = visitData.Add(Visit);
                visitData.Commit();
                TempData["Message2"] = "Thank you for your purchase !";

                return RedirectToPage("./List");
            }
            Customers = customerData.GetCustomers().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return Page();
        }
    }
}