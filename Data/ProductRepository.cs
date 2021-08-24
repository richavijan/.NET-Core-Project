using Core.Contract;
using Core.Model;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactored.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;

        public ProductRepository(ProductDbContext db)
        {
            _db = db;
        }
        public void CreateProductAsync(Product product)
        {
            _db.Products.Add(product);
        }

        public void CreateProductOptionsAsync(int productId, ProductOptions productOptions)
        {
            productOptions.ProductId = productId;
            _db.ProductOptions.Add(productOptions);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var dbProducts = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            var dbProductOptions =  _db.ProductOptions.Where(x => x.ProductId == id); 
            _db.ProductOptions.Remove((ProductOptions)dbProductOptions);
            _db.Products.Remove(dbProducts);
            return id;
        }

        public async Task<int> DeleteProductOptionsAsync(int id)
        {
            var dbrow = await _db.ProductOptions.Where(x => x.Id == id).FirstOrDefaultAsync();
            _db.ProductOptions.Remove(dbrow);
            return id;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var query = _db.Products.Where(x => x.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductOptions>> GetProductOptionsAsync(int productId)
        {
            var query = _db.ProductOptions.Where(x => x.ProductId == productId);
            return await query.ToListAsync();
        }

        public async Task<ProductOptions> GetProductOptionsAsync(int productId, int id)
        {
            var query = _db.ProductOptions.Where(x => x.ProductId == productId && (x.Id == id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateProductAsync(int id, Product product)
        {
            var dbrow = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            dbrow.Description = product.Description;
            dbrow.DeliveryPrice = product.DeliveryPrice;
            dbrow.Price = product.Price;
            return id;
        }

        public async Task<int> UpdateProductOptionsAsync(int id, ProductOptions productOptions)
        {
            var dbrow = await _db.ProductOptions.Where(x => x.Id == id).FirstOrDefaultAsync();
            dbrow.ProductId = productOptions.ProductId;
            dbrow.Name = productOptions.Name;
            dbrow.Description = productOptions.Description;
            return id;
        }
    }
}
