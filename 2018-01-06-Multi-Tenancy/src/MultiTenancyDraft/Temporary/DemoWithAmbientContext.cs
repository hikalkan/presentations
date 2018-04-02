using System;
using System.Collections.Generic;
using System.Linq;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Temporary
{
    public class DemoWithAmbientContext
    {
        public List<Product> SearchProducts(string productName)
        {
            return GetAllProducts()
                .Where(p => p.Name.Contains(productName))
                .ToList();
        }

        private List<Product> GetAllProducts()
        {
            return GetAllProductsFromRepository();
        }

        private List<Product> GetAllProductsFromRepository()
        {
            return GetAllProductsFromDbContext();
        }

        private List<Product> GetAllProductsFromDbContext()
        {
            var tenantId = TenantInfo.Current.Id;
            throw new NotImplementedException();
        }
    }
}