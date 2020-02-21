using BeautyShop.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Data
{
    public class BeautyShopDbContext : DbContext
    {
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public BeautyShopDbContext(DbContextOptions<BeautyShopDbContext> options) : base(options)
        {

        }
    }
}
