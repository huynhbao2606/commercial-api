using AzureAPI.Dao.IRepository;
using AzureAPI.Data;
using AzureAPI.Entities;

namespace AzureAPI.Dao
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<ProductType> _productTypeRepository;
        private IGenericRepository<ProductBrand> _productBrandRepository;


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        IGenericRepository<Product> IUnitOfWork.ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_context);
                }

                return _productRepository;
            }
        }

        IGenericRepository<ProductType> IUnitOfWork.ProductTypeRepository
        {
            get
            {
                if (_productTypeRepository == null)
                {
                    this._productTypeRepository = new GenericRepository<ProductType>(_context);
                }

                return _productTypeRepository;
            }
        }


        IGenericRepository<ProductBrand> IUnitOfWork.ProductBrandRepository
        {
            get
            {
                if (_productBrandRepository == null)
                {
                    this._productBrandRepository = new GenericRepository<ProductBrand>(_context);
                }

                return _productBrandRepository;
            }
        }


        void IDisposable.Dispose()
        {
            _context.Dispose();
        }

        void IUnitOfWork.Save()
        {
            _context.SaveChanges();
        }

    }
}
