using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;
using Northwind.Infrastructure.Interfaces;
using Northwind.Models;

namespace Northwind.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataEntities _context = new DataEntities();

        private IRepository<Customer> _customerRepository;

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new GenericRepository<Customer>(_context);
                }

                return _customerRepository;
            }
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
        }
    }
}
