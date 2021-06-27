using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getAllProduct();
        Task<Product> getProductDetails(int id);
        Task<bool> insertProduct(Product product);
        Task<bool> updateProduct(Product product);
        Task<bool> deleteProduct(int id);
    }
}
