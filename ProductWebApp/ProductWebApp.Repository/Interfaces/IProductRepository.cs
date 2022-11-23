using ProductWebApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebApp.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProduct(int productId);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }

}
