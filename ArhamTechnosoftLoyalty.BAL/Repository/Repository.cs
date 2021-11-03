using ArhamTechnosoftLoyalty.BAL.Utility;
using ArhamTechnosoftLoyalty.DAL.Data;
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

        public Response<T> Add(T entity)
        {
            Response<T> response = new Response<T>();
            try
            {
                var retval = dbSet.Add(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<T> AddRange(IEnumerable<T> entity)
        {
            Response<T> response = new Response<T>();
            try
            {
                dbSet.AddRange(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
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

        public Response<T> Remove(int id)
        {
            Response<T> response = new Response<T>();
            try
            {
                T entity = dbSet.Find(id);
                response = Remove(entity);

            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;

        }

        public Response<T> Remove(T entity)
        {
            Response<T> response = new Response<T>();
            try
            {
                dbSet.Remove(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<T> RemoveRange(IEnumerable<T> entity)
        {
            Response<T> response = new Response<T>();
            try
            {
                dbSet.RemoveRange(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
