using System;
using System.Linq.Expressions;
using AzureAPI.Dao.IRepository;
using AzureAPI.Data;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Helper;

namespace AzureAPI.Dao
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> dbSet = null;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = dbSet.AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<PagedList<T>> GetEntities(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "",
    PaginationParams pagingParams = null)
        {
            var query = PrepareQuery(filter, orderBy, includeProperties);

            if (pagingParams != null)
            {
                return await PagedList<T>.CreateAsync(query, pagingParams.PageNumber, pagingParams.PageSize);
            }

            return await PagedList<T>.CreateAsync(query, 1, await query.CountAsync());
        }

        private IQueryable<T> PrepareQuery(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void DeleteById(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

    }
}
