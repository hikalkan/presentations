using Volo.Abp.DependencyInjection;

namespace Demo.Shared
{
    public class ProductService : ISingletonDependency
    {
        private readonly Dictionary<string, ProductInfo> _products = new()
        {
            { "A01", new ProductInfo("A01", "Acme Jet Motor", 99) },
            { "A02", new ProductInfo("A01", "Acme Integrating Pistol", 49) },
            { "A03", new ProductInfo("A01", "Acme Bird Seed", 14.99f) }
        };

        public async Task<ProductInfo> GetAsync(string productCode)
        {
            return _products.GetValueOrDefault(productCode)
                ?? throw new Exception("Given product could not be found!");
        }
    }
}
