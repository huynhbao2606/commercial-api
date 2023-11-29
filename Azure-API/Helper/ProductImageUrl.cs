using AutoMapper;
using AzureAPI.Entities;
using AzureAPI.DTO;

namespace AzureAPI.Helper
{
    public class ProductImageUrl : IValueResolver<Product, ProductDTO, string>
    {
        private IConfiguration _config;

        public ProductImageUrl(IConfiguration config) {

            _config = config;

        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {

                string baseUrl = _config["ApiUrl"];
                return baseUrl + source.PictureUrl;

            }

            return null;

        }
    }
}
