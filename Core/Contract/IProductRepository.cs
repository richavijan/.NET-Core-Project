using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductAsync(int id);
        void CreateProductAsync(Product product);
        Task<int> UpdateProductAsync(int id, Product product);
        Task<int> DeleteProductAsync(int id);
        Task<IEnumerable<ProductOptions>> GetProductOptionsAsync(int productId);
        Task<ProductOptions> GetProductOptionsAsync(int productId, int id);
        void CreateProductOptionsAsync(int productId, ProductOptions productOptions);
        Task<int> UpdateProductOptionsAsync(int id, ProductOptions productOptions);
        Task<int> DeleteProductOptionsAsync(int id);
    }
}
