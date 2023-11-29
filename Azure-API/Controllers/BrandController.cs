using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Entities;
using AzureAPI.Dao.IRepository;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrand()
        {
            var brands = await _unitOfWork.ProductBrandRepository.GetAll();

            return Ok(brands);

        }


        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetSingleBrand(int id)
        {
            var brand = await _unitOfWork.ProductBrandRepository.GetById(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        
    }
}
