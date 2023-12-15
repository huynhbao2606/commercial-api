using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure_API.Entities;

namespace Azure_API.Dao.IRepository;

public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string basketId);

    Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

    Task<bool> DeleteBasketAsync(string basketId);

}
