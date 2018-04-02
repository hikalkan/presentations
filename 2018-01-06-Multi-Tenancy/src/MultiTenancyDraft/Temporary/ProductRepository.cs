using System;
using System.Linq;
using MultiTenancyDraft.Application;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Temporary
{
    public class ProductRepository
    {
        private readonly MyDbContext _dbContext;

        public ProductRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetAll()
        {
            var currentTenantId = TenantInfo.Current?.Id;
            return _dbContext.Products.Where(p => p.TenantId == currentTenantId);
        }

        public Product FindById(Guid id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public Product FindByName(string name)
        {
            return GetAll().FirstOrDefault(p => p.Name == name);
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
        }
    }
}
