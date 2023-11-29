using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AzureAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description {get; set;}

        [Precision(38,2)]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }


        public int ProductBrandId { get; set; }
        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrand { get; set; }

        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
    }
}
