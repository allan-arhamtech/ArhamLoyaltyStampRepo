
using ArhamTechnosoftLoyalty.DAL.Data;
using ArhamTechnosoftLoyalty.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.BAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ArhamTechLoyaltyDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ArhamTechLoyaltyDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public CustomResponse<T> Add(T entity)
        {
            CustomResponse<T> response = new CustomResponse<T>();
            try
            {
                var retval = dbSet.Add(entity);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
            }
            return response;
        }

        public CustomResponse<T> AddRange(IEnumerable<T> entity)
        {
            CustomResponse<T> response = new CustomResponse<T>();
            try
            {
                dbSet.AddRange(entity);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
            }
            return response;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public CustomResponse<T> Remove(int id)
        {
            CustomResponse<T> response = new CustomResponse<T>();
            try
            {
                T entity = dbSet.Find(id);
                response = Remove(entity);

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
            }
            return response;

        }

        public CustomResponse<T> Remove(T entity)
        {
            CustomResponse<T> response = new CustomResponse<T>();
            try
            {
                dbSet.Remove(entity);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
            }
            return response;
        }

        public CustomResponse<T> RemoveRange(IEnumerable<T> entity)
        {
            CustomResponse<T> response = new CustomResponse<T>();
            try
            {
                dbSet.RemoveRange(entity);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.isSuccess = false;
            }
            return response;
        }
    }
}
