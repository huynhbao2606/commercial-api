using AzureAPI.Entities;


namespace AzureAPI.Dao.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<ProductType> ProductTypeRepository { get; }
        IGenericRepository<ProductBrand> ProductBrandRepository { get; }
    }
}
