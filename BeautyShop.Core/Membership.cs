using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Core
{
    public class Membership
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double DiscountService { get; set; }
        public double DiscountProduct { get; set; }
    }
}
