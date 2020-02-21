using BeautyShop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Data
{
    public interface IMembrship
    {
        Membership GetMembership(int? id);
        List<Membership> GetMembrships();
    }
}
