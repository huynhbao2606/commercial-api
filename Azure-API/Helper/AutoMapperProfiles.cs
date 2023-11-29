using AutoMapper;
using AzureAPI.Entities;
using AzureAPI.DTO;

namespace AzureAPI.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductBrand,opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, otp => otp.MapFrom<ProductImageUrl>());
        }
    }
}
