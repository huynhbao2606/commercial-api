
using Microsoft.AspNetCore.Mvc;
using AzureAPI.Entities;
using AzureAPI.Dao.IRepository;
using AzureAPI.DTO;
using AzureAPI.Helper;
using AutoMapper;
using System.Linq.Expressions;


using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts(
            [FromQuery] ProductRequestParams productRequestParams,
            [FromQuery] PaginationParams pagination)
        {

            var query = await _unitOfWork.ProductRepository.GetEntities(
                filter: buildFilter(productRequestParams),
                orderBy: buildSortQuery(productRequestParams),
                includeProperties: "ProductType,ProductBrand",
                pagination: pagination);

            var productDto = _mapper.Map<IEnumerable<ProductDTO>>(query);

         

            return Ok(productDto);
        }

        private Func<IQueryable<Product>, IOrderedQueryable<Product>> buildSortQuery(ProductRequestParams productRequestParams)
        {
            return productRequestParams.Sort switch //Sort
            {
                "priceAsc" => p => p.OrderBy(i => i.Price),
                "priceDesc" => p => p.OrderByDescending(i => i.Price),
                "typeAsc" => p => p.OrderBy(i => i.ProductTypeId),
                "typeDesc" => p => p.OrderByDescending(i => i.ProductTypeId),
                "brandAsc" => p => p.OrderBy(i => i.ProductBrandId),
                "brandDesc" => p => p.OrderByDescending(i => i.ProductBrandId),
                _ => p => p.OrderBy(i => i.Name)
            };
        }
        private Expression<Func<Product, bool>> buildFilter(ProductRequestParams productRequestParams)
        {

            int? brandId = productRequestParams.BrandId;

            int? typeId = productRequestParams.TypeId;

            string search = productRequestParams.Search;

            return x =>
            (string.IsNullOrEmpty(search) || x.Name.ToLower().Contains(search)) && // search
                (!typeId.HasValue || x.ProductTypeId == typeId) &&
                (!brandId.HasValue || x.ProductBrandId == brandId); //Filter
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductDTO>>> GetSingleProduct(int id)
        {
            var query = await _unitOfWork.ProductRepository.GetEntities(
                filter: i => i.Id == id,
                includeProperties: "ProductType,ProductBrand");

            Product product = query.FirstOrDefault();

            ProductDTO productdto = _mapper.Map<ProductDTO>(product);


            return Ok(productdto);
        }



    }
}
