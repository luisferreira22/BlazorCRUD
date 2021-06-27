using BlazorCRUD.Data.Dapper.Repositories;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Services
{
    public class ProductService : IProductService
    {
        private readonly SqlConfiguration _configuration;
        private IProductRepository _IproductRepository;

        public ProductService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _IproductRepository = new ProductRepository(configuration.ConnectionString);
        }

        public Task<bool> deleteProduct(int id)
        {
            return _IproductRepository.deleteProduct(id);
        }

        public Task<IEnumerable<Product>> getAllProduct()
        {
            return _IproductRepository.getAllProduct();
        }

        public Task<Product> getProductDetails(int id)
        {
            return _IproductRepository.getProductDetails(id);
        }

        public Task<bool> saveProduct(Product product)
        {
            if (product.ProductId == 0)
                return _IproductRepository.insertProduct(product);
            else
                return _IproductRepository.updateProduct(product);
        }
    }
}
