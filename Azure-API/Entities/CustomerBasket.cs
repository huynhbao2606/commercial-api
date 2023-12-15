using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_API.Entities;

public class CustomerBasket
{
    public string Id { get; set; }

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    public CustomerBasket()
    {
    }

    public CustomerBasket(string id)
    {
        Id = id;
    }

    public decimal Total()
    {
        return Items.Sum(x => x.Price * x.Quantity);
    }

    public void AddItem(BasketItem item)
    {
        var existingItem = Items.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem == null)
        {
            Items.Add(item);
        }
        else
        {
            existingItem.Quantity += item.Quantity;
        }
    }

    public void RemoveItem(BasketItem item)
    {
        var existingItem = Items.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            Items.Remove(existingItem);
        }
    }

    public void UpdateItem(BasketItem item)
    {
        var existingItem = Items.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Quantity = item.Quantity;
        }
    }

    public void ClearBasket()
    {
        Items.Clear();
    }

}
