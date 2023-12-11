namespace AzureAPI.Helper
{
    public class ProductRequestParams : PaginationParams
    {
        public int? BrandId { get; set; }

        public int? TypeId {get; set; }

        public string Sort { get; set; }

        public string Search { get; set; }
    }
}
