using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Mvc.Areas.Customers.ViewModels
{
    public class QuickSearchResult
    {
        public List<CustomerViewModel> Customers { get; set; }
        public int Total { get; set; }
        public string SearchText { get; set; }
    }
}