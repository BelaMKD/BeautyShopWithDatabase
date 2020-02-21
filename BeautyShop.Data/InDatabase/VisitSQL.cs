using BeautyShop.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShop.Data.InDatabase
{
    public class VisitSQL : IVisit
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public VisitSQL(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }
        public Visit Add(Visit visit)
        {
            var tempVisit = beautyShopDbContext.Visits.Add(visit);
            return tempVisit.Entity;
        }

        public int Commit()
        {
            return beautyShopDbContext.SaveChanges();
        }

        public Visit GetVisit(int id)
        {
            return beautyShopDbContext.Visits.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Visit> GetVisits(string name = null)
        {
            return beautyShopDbContext.Visits
                .Include(x=>x.Customer.Membership)
                .Include(x=>x.Customer)
                .Include(x=>x.ShopItems)
                .Where(x => string.IsNullOrEmpty(name) || x.Customer.Name.StartsWith(name)).ToList();
        }
    }
}
