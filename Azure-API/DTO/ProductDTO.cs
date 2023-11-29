using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureAPI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Precision(38, 2)]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
