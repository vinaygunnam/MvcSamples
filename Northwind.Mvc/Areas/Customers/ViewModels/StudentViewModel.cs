using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Models;

namespace Northwind.Mvc.Areas.Customers.ViewModels
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        
        public CustomerViewModel()
        {
            
        }

        public CustomerViewModel(Customer customer)
        {
            if (customer != null)
            {
                this.Id = customer.CustomerID;
                this.FullName = customer.ContactName;
                this.CompanyName = customer.CompanyName;
            }
        }
    }
}