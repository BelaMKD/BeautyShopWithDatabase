using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Core
{
    public class VisitTP
    {
        public List<double> Total { get; set; }
        public List<ShopItem> ShopItems { get; set; }
        public VisitTP()
        {
            ShopItems = new List<ShopItem>();
            Total = new List<double>();
        }
        public void AddShopItem(ShopItem shopItem)
        {
            ShopItems.Add(shopItem);
        }
        public double TotalPrice(Visit visit)
        {
            var total = 0.0;

            foreach (var item in visit.ShopItems)
            {
                if (item.ItemType == ItemType.Product)
                {
                    if (visit.Customer.IsMember)
                    {
                        total += item.Price * (1 - visit.Customer.Membership.DiscountProduct);
                    }
                    else
                    {
                        total += item.Price;
                    }
                }
                if (item.ItemType == ItemType.Service)
                {
                    if (visit.Customer.IsMember)
                    {
                        total += item.Price * (1 - visit.Customer.Membership.DiscountService);
                    }
                    else
                    {
                        total += item.Price;
                    }
                }
            }
            return total;
        }
    }
}
