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
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private string connectionString;
        public InvoiceDetailRepository(string pconnectionString)
        {
            connectionString = pconnectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(connectionString);
        }

        public async Task<bool> deleteInvoiceDetail(int id)
        {
            var db = dbConnection();
            var sql = @"Delete InvoiceDetail where  InvoiceDetailId=@id";
            var result = await db.ExecuteAsync(sql.ToString(), new { id = id });
            return result > 0;
        }



        public async Task<InvoiceDetail> getInvoiceDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT InvoiceDetailId, InvoiceId, ProductId, Amount, SellPrice, Total FROM InvoiceDetail where InvoiceDetailId=@id";
            return await db.QueryFirstOrDefaultAsync<InvoiceDetail>(sql.ToString(), new { id });
        }

        public async Task<IEnumerable<InvoiceDetail>> getInvoiceDetailsByInvoiceId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT InvoiceDetailId, InvoiceId, ProductId, Amount, SellPrice, Total FROM InvoiceDetail where InvoiceId=@id";
            return await db.QueryAsync<InvoiceDetail>(sql.ToString(), new { id });
        }

        public async Task<bool> insertInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            var db = dbConnection();
            var sql = @"Insert into InvoiceDetail( InvoiceId, ProductId, Amount, SellPrice) 
                                    values (@InvoiceId, @ProductId, @Amount, @SellPrice) ";
            var result = await db.ExecuteAsync(sql.ToString(), new { invoiceDetail.InvoiceId, invoiceDetail.ProductId, invoiceDetail.Amount, invoiceDetail.SellPrice });
            return result > 0;
        }

        public async Task<bool> updateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            var db = dbConnection();
            var sql = @"Update InvoiceDetail Set  InvoiceId=@InvoiceId, ProductId=@ProductId, Amount=@Amount, SellPrice=@SellPrice
                       where InvoiceDetailId=@InvoiceDetailId";
            var result = await db.ExecuteAsync(sql.ToString(), new { invoiceDetail.InvoiceId, invoiceDetail.ProductId, invoiceDetail.Amount, invoiceDetail.SellPrice, invoiceDetail.InvoiceDetailId }) ;
            return result > 0;
        }

        public async Task<bool> deleteInvoiceDetailByInvoiceId(int id)
        {
            var db = dbConnection();
            var sql = @"Delete InvoiceDetail where  InvoiceId=@id";
            var result = await db.ExecuteAsync(sql.ToString(), new { id = id });
            return result > 0;
        }


    }
}
