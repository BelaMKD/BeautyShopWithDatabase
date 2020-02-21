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

        [BindProperty]
        public Visit Visit { get; set; }
        [BindProperty]
        public VisitTP VisitTP { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public string Message { get; set; }
        public ShopModel(IVisit visitData, ICustomer customerData)
        {
            this.visitData = visitData;
            this.customerData = customerData;
        }
        public void OnGet()
        {
            Visit = new Visit();
            VisitTP = new VisitTP();
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
                    VisitTP.AddShopItem(shopItem);
                    Visit.ShopItems.Add(shopItem);
                }
                if (priceService > 0 && priceService.HasValue)
                {
                    ShopItem shopItem = new ShopItem
                    {
                        ItemType = ItemType.Service,
                        Price = priceService.Value
                    };
                    VisitTP.AddShopItem(shopItem);
                    Visit.ShopItems.Add(shopItem);
                }
                VisitTP.Total.Add(VisitTP.TotalPrice(Visit));
            }
            Message = Visit.CustomerId == null ? "No customer selected!" : $"Total pay: {VisitTP.Total.Sum()}";
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
                Visit.ShopItems = VisitTP.ShopItems;
                Visit.Pay = VisitTP.Total.Sum();
                Visit = visitData.Add(Visit);
                visitData.Commit();
                TempData["Message2"] = "Thank you for your purchase!";

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