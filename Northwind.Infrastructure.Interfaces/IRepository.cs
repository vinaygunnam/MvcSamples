using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        T GetByID(object id);
        void Delete(object id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
    }
}
