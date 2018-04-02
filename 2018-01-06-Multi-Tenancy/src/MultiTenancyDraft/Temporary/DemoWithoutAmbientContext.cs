using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiTenancyDraft.Temporary
{
    public class DemoWithoutAmbientContext
    {
        public List<Product> SearchProducts(string productName, Guid? tenantId)
        {
            return GetAllProducts(tenantId)
                .Where(p => p.Name.Contains(productName))
                .ToList();
        }

        private List<Product> GetAllProducts(Guid? tenantId)
        {
            return GetAllProductsFromRepository(tenantId);
        }

        private List<Product> GetAllProductsFromRepository(Guid? tenantId)
        {
            return GetAllProductsFromDbContext(tenantId);
        }

        private List<Product> GetAllProductsFromDbContext(Guid? tenantId)
        {
            //tenantid is only needed here!
            throw new NotImplementedException();
        }
    }
}