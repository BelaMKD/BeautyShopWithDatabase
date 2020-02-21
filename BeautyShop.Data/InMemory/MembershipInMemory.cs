using System;
using System.Collections.Generic;
using System.Linq;
using BeautyShop.Core;

namespace BeautyShop.Data
{
    public class MembershipInMemory : IMembrship
    {
        public List<Membership> Memberships { get; set; }

        public List<Membership> GetMembrships()
        {
            return Memberships;
        }

        public Membership GetMembership(int? id)
        {
            return Memberships.SingleOrDefault(x => x.Id == id);
        }
    }
}
