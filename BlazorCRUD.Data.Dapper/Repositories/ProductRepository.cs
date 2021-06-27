using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString;
        public ProductRepository(string pconnectionString)
        {
            connectionString = pconnectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(connectionString);
        }
        public async Task<bool> deleteProduct(int id)
        {
            var db = dbConnection();
            var sql = @"Delete Product where where ProductId=@id";
            var result = await db.ExecuteAsync(sql.ToString(), new { id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Product>> getAllProduct()
        {
            var db = dbConnection();
            var sql = @"SELECT ProductId, Name, UnitPrice, Description, Picture FROM Product";
            return await db.QueryAsync<Product>(sql.ToString(), new { });
        }

        public async Task<Product> getProductDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT ProductId, Name, UnitPrice, Description, Picture  FROM Product where ProductId=@id";
            return await db.QueryFirstOrDefaultAsync<Product>(sql.ToString(), new { id });
        }

        public async  Task<bool> insertProduct(Product product)
        {
            var db = dbConnection();
            var sql = @"Insert into Product( Name, UnitPrice, Description, Picture) 
                                    values (@Name, @UnitPrice, @Description, @Picture) ";
            var result = await db.ExecuteAsync(sql.ToString(), new { product.Name, product.UnitPrice, product.Description, product.Picture});
            return result > 0;
        }

        public async Task<bool> updateProduct(Product product)
        {
            var db = dbConnection();
            var sql = @"Update Product Set  Name=@Name, UnitPrice=@UnitPrice, Description=@Description, Picture=@Picture
                       where ProductId=@ProductId";
            var result = await db.ExecuteAsync(sql.ToString(), new { product.Name, product.UnitPrice, 
                                                                     product.Description,product.Picture, product.ProductId }); 
            return result > 0;
        }
    }
}
