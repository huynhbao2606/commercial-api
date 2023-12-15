using AzureAPI.Entities;
using System.Linq.Expressions;
using AzureAPI.Helper;

namespace AzureAPI.Dao.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);

        Task<IEnumerable<T>> GetAll();

        Task<PagedList<T>> GetEntities(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "",
    PaginationParams pagingParams = null);



        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
