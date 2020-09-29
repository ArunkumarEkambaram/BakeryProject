using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
    }
}
