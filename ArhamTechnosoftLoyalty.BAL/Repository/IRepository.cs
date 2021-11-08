
using ArhamTechnosoftLoyalty.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = null
            );

        T GetFirstOrDefault(
                Expression<Func<T, bool>> filter = null,
                string includeProperties = null
            );

        CustomResponse<T> Add(T entity);

        CustomResponse<T> Remove(int id);

        CustomResponse<T> Remove(T entity);

        CustomResponse<T> RemoveRange(IEnumerable<T> entity);
    }
}
