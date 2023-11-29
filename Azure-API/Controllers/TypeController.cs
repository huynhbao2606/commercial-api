using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AzureAPI.Dao.IRepository;
using AzureAPI.Entities;
namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            var types = await _unitOfWork.ProductTypeRepository.GetAll();

            return Ok(types);
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetSingleType(int id)
        {
            var type = await _unitOfWork.ProductTypeRepository.GetById(id);

            if (type == null)
            {
                return NotFound();
            }

            return type;
        }

    }
}
