using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryProject.Data;
using BakeryProject.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
                throw new NullReferenceException(nameof(product));
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}
