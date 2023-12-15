using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure_API.Dao.IRepository;
using Azure_API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Azure_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    [HttpGet("{id}")] // api/basket
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
        var basket = await _basketRepository.GetBasketAsync(id);

        return Ok(basket ?? new CustomerBasket(id));
    }

    [HttpPost]// api/basket
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
    {
        var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

        return Ok(updatedBasket);
    }

    [HttpDelete("{id}")] // api/basket
    public async Task DeleteBasketAsync(string id)
    {
        await _basketRepository.DeleteBasketAsync(id);
    }

}
