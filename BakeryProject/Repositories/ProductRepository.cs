using System;
using System.Collections.Generic;
using System.Linq;
using BakeryProject.Data;
using BakeryProject.Models;

namespace BakeryProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext dbContext = null;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddNewProduct(Product product)
        {
            if (product != null)
            {
                dbContext.Products.Add(product);
                return dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(product));
            }
        }

        public int EditProduct(int id, Product product)
        {
            var productFromDb = GetProductById(id);
            if (productFromDb != null)
            {
                productFromDb.Name = product.Name;
                productFromDb.Description = product.Description;
                productFromDb.Price = product.Price;
                productFromDb.ImageName = product.ImageName;
                return dbContext.SaveChanges();
            }
            else
            {
                throw new NullReferenceException(nameof(product));
            }
        }

        public Product GetProductById(int id)
        {
            return dbContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}
