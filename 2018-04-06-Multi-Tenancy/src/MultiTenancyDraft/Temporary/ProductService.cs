using System;

namespace MultiTenancyDraft.Temporary
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void ChangeName(Guid productId, string newName)
        {
            var product = _productRepository.FindById(productId);
            product.Name = newName;
            _productRepository.Update(product);
        }
    }
}
