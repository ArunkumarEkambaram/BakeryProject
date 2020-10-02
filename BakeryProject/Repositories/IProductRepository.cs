using System.Collections.Generic;
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
