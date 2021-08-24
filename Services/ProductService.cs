using Core.Contract;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> CreateProductOptionsAsync(int productId, ProductOptions productOptions)
        {
            _productRepository.CreateProductOptionsAsync(productId,productOptions);
            await _productRepository.SaveChangesAsync();
            return productOptions.Id;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var result = await _productRepository.DeleteProductAsync(id);
            await _productRepository.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteProductOptionsAsync(int id)
        {
            var result = await _productRepository.DeleteProductOptionsAsync(id);
            await _productRepository.SaveChangesAsync();
            return result;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var result = await _productRepository.GetProductAsync(id);
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var result = await _productRepository.GetProductAsync();
            return result;
        }

        public async Task<IEnumerable<ProductOptions>> GetProductOptionsAsync(int productId)
        {
            var result = await _productRepository.GetProductOptionsAsync(productId);
            return result;
        }

        public async Task<ProductOptions> GetProductOptionsAsync(int productId, int id)
        {
            var result = await _productRepository.GetProductOptionsAsync(productId,id);
            return result;
        }

        public async Task<int> UpdateProductAsync(int id, Product product)
        {
            var result = await _productRepository.UpdateProductAsync(id, product);
            await _productRepository.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateProductOptionsAsync(int id, ProductOptions productOptions)
        {
            var result = await _productRepository.UpdateProductOptionsAsync(id, productOptions);
            await _productRepository.SaveChangesAsync();
            return result;
        }
    }
}
