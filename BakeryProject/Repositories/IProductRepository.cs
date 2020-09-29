using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryProject.Models;

namespace BakeryProject.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int id);

        int AddNewProduct(Product product);

        int EditProduct(int id, Product product);

    }
}
