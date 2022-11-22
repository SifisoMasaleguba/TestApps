using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebApp.Entities.Models;
using ProductWebApp.Repository;

namespace ProductWebApp.Business
{
    public class ProductManager
    {
        private ProductRepository repository;
        public ProductManager()
        {
            repository = new ProductRepository();
        }

        public IEnumerable<Product> GetProducts(int productId)
        {
            return repository.GetProduct(productId);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAllProduct();
        }

        public void AddBulkProduct(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                repository.AddProduct(product);
            }
        }

        public void DeleteProduct(int productId)
        {
             repository.DeleteProduct(productId);
        }
    }
}
