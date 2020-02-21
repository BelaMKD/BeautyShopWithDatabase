using BeautyShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShop.Data.InDatabase
{
    public class MembershipSQL : IMembrship
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public MembershipSQL(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }
        public Membership GetMembership(int? id)
        {
            return beautyShopDbContext.Memberships.SingleOrDefault(x => x.Id == id);
        }

        public List<Membership> GetMembrships()
        {
            return beautyShopDbContext.Memberships.ToList();
        }
    }
}
