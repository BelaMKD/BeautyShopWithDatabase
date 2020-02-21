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
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        public IEnumerable<BeautyShop.Core.Visit> Visits { get; set; }
        [TempData]
        public string Message2 { get; set; }
        public ListModel(IVisit visitData)
        {
            this.visitData = visitData;
        }
        public void OnGet()
        {
            Visits = visitData.GetVisits(SearchName);
        }
    }
}