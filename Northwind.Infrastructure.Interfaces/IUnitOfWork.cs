using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Models;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        void Commit();
    }
}
