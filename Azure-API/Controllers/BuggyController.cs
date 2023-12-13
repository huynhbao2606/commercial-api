﻿using Microsoft.AspNetCore.Mvc;
using AzureAPI.Dao.IRepository;
using AzureAPI.Entities;
using AzureAPI.Exceptions;

namespace AzureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuggyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// 404 page not foud

        /// 404 bad reques
        /// 
        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ErrorResponse(400));

        }

        /// 400 validation error -- input string in the id field    
        /// 
        [HttpGet("bad-request/{id}")]
        public ActionResult GetValidationError(int id)
        {

            return Ok();


        }


        /// 500 server error
        ///     
        [HttpGet("server-error")]
        public async Task<ActionResult> GetSeverError()
        {
            Product notfountProduct = await _unitOfWork.ProductRepository.GetById("1000");

            if (notfountProduct == null) return BadRequest();

            return Ok(notfountProduct.ToString());

        }
    }
}
