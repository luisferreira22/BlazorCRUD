using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interface
{
   public interface IProductService
    {
        Task<IEnumerable<Product>> getAllProduct();
        Task<Product> getProductDetails(int id);
        Task<bool> saveProduct(Product product);
        Task<bool> deleteProduct(int id);
    }
}
