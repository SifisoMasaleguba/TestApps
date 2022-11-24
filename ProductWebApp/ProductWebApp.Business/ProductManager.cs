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
  

        public IEnumerable<Product> GetProducts(int productId)
        {
            ProductRepository repository = new ProductRepository();
            return repository.GetProduct(productId);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            ProductRepository repository = new ProductRepository();
            return repository.GetAllProduct();
        }

        public void AddBulkProduct(IEnumerable<Product> products)
        {
            ProductRepository repository = new ProductRepository();
            foreach (var product in products)
            {
                repository.AddProduct(product);
            }
        }
        public Product AddProduct(Product product)
        {
            ProductRepository repository = new ProductRepository();
            return repository.AddProduct(product);
           
        }
        public Product UpdateProduct(Product product)
        {
            ProductRepository repository = new ProductRepository();
            return repository.UpdateProduct(product);

        }
        public void DeleteProduct(Product product)
        {
            ProductRepository repository = new ProductRepository();
            repository.DeleteProduct(product);
        }
        public int GetProductNumber() {
            ProductRepository repository = new ProductRepository();
            return repository.GetProductNumber();
        }
    }
}
