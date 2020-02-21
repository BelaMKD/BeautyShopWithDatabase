using BeautyShop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyShop.Data
{
    public interface IVisit
    {
        Visit Add(Visit visit);
        Visit GetVisit(int id);
        IEnumerable<Visit> GetVisits(string name = null);
        int Commit();
    }
}
