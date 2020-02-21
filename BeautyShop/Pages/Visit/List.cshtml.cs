using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyShop.Core;
using BeautyShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop.Pages.Visit
{
    public class ListModel : PageModel
    {
        private readonly IVisit visitData;
        private readonly VisitTP visitTP;

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        public IEnumerable<BeautyShop.Core.Visit> Visits { get; set; }
        [TempData]
        public string Message2 { get; set; }
        public ListModel(IVisit visitData, VisitTP visitTP)
        {
            this.visitData = visitData;
            this.visitTP = visitTP;
        }
        public void OnGet()
        {
            Visits = visitData.GetVisits(SearchName);
        }
        public double GetPrice(BeautyShop.Core.Visit visit)
        {
            return visitTP.TotalPrice(visit);
        }
    }
}