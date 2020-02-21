using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeautyShop.Core
{
    public class Visit
    {
        public Visit()
        {
            ShopItems = new List<ShopItem>();
        }
        public int Id { get; set; }
        [Required, Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ShopItem> ShopItems { get; set; }
        public double Pay { get; set; }

    }
}
