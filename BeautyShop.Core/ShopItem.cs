using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Core
{
    public class ShopItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public ItemType ItemType { get; set; }
        public int VisitId { get; set; }
        
    }
}
