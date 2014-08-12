using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Mvc.Areas.Customers.ViewModels
{
    public class FullSearchResult
    {
        public List<CustomerViewModel> Customers { get; set; }
        public string SearchText { get; set; }
    }
}