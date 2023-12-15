using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure_API.Dao.IRepository;
using Azure_API.Entities;
using AzureAPI.Dao.IRepository;
using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using IDatabase = StackExchange.Redis.IDatabase;

namespace Azure_API.Dao;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _db;
    private readonly IUnitOfWork _iUnitOfWork;

    public BasketRepository(IConnectionMultiplexer redis, IUnitOfWork iUnitOfWork)
    {
        _db = redis.GetDatabase();
        _iUnitOfWork = iUnitOfWork;
    }
    public async Task<bool> DeleteBasketAsync(string basketId)
    {
        return await _db.KeyDeleteAsync(basketId);
    }

    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
        var data = await _db.StringGetAsync(basketId);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        List<BasketItem> items = new List<BasketItem>();

        foreach (var item in basket.Items)
        {
            var query = await _iUnitOfWork.ProductRepository.GetEntities(
                filter: x => x.Id == item.Id,
                includeProperties: "ProductType,ProductBrand"
                );
            Product product = query.FirstOrDefault();
            BasketItem basketItem = new BasketItem
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = item.Quantity,
                PictureUrl = product.PictureUrl,
                Type = product.ProductType.Name,
                Brand = product.ProductBrand.Name,
                Description = product.Description
            };
            items.Add(basketItem);
        }

        basket.Items = items;

        var created = await _db.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

        return created ? await GetBasketAsync(basket.Id) : null;
    }
}
