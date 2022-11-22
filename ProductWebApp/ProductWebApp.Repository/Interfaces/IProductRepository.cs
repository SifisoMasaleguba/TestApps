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
        void AddProduct(Product product);       
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }

}
