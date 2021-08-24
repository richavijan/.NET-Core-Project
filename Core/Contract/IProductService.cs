
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductAsync(int id);
        Task<int> CreateProductAsync(Product product);
        Task<int> UpdateProductAsync(int id, Product product);
        Task<int> DeleteProductAsync(int id);
        Task<IEnumerable<ProductOptions>> GetProductOptionsAsync(int productId);
        Task<ProductOptions> GetProductOptionsAsync(int productId, int id);
        Task<int> CreateProductOptionsAsync(int productId, ProductOptions productOptions);
        Task<int> UpdateProductOptionsAsync(int id, ProductOptions productOptions);
        Task<int> DeleteProductOptionsAsync(int id);
    }
}
