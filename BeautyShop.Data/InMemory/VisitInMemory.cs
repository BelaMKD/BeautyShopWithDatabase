using BeautyShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyShop.Data.InMemory
{
    public class VisitInMemory : IVisit
    {
        public List<Visit> Visits { get; set; }
        public VisitInMemory()
        {
            Visits = new List<Visit>();
        }
        public Visit Add(Visit visit)
        {
            visit.Id = Visits.Any() ? Visits.Max(x => x.Id) + 1 : 1;
            Visits.Add(visit);
            return visit;
        }

        public int Commit()
        {
            return 0;
        }

        public Visit GetVisit(int id)
        {
            return Visits.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Visit> GetVisits(string name = null)
        {
            return Visits.Where(x => string.IsNullOrEmpty(name) || x.Customer.Name.ToLower().StartsWith(name.ToLower()));
        }

    }
}
