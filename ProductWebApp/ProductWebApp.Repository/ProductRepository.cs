using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProductWebApp.Entities.Models;
using ProductWebApp.Repository.DataSource;
using ProductWebApp.Repository.Interfaces;

namespace ProductWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        DataSourceWeb dataSourceWeb;
        public ProductRepository() {
            dataSourceWeb = new DataSourceWeb();
        }



        public void DeleteProduct(Product product) {           
            var parameters = new DynamicParameters();            
            parameters.Add("@ProductId", product.ProductId);
            dataSourceWeb.Connection().Execute("STP_PRODUCT_DELETE", parameters, commandType: CommandType.StoredProcedure);
        }

        public Product AddProduct(Product product)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", product.Name);
            parameters.Add("@Price", product.Price);
            parameters.Add("@ReleaseDate", product.ReleaseDate);         
            dataSourceWeb.Connection().Execute("STP_PRODUCT_ADD", parameters, commandType: CommandType.StoredProcedure);
            return product;
            
        }

        public IEnumerable<Product> GetProduct(int productId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);      

            var results = dataSourceWeb.Connection().Query<Product>("STP_PRODUCTS", parameters, commandType: CommandType.StoredProcedure).ToList();
            return results;
        }
        public IEnumerable<Product> GetAllProduct()
        {
            return dataSourceWeb.Connection().Query<Product>("STP_PRODUCTS", null, commandType: CommandType.StoredProcedure).ToList();            
        }

        public Product UpdateProduct(Product product)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", product.ProductId);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Price", product.Price);
            parameters.Add("@ReleaseDate", product.ReleaseDate);
            dataSourceWeb.Connection().Execute("STP_PRODUCT_UPDATE", parameters, commandType: CommandType.StoredProcedure);
            return product;
        }
    }
}
