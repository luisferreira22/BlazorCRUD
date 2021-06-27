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
    public class InvoiceRepository : IInvoiceRepository
    {
        private string connectionString;
        public InvoiceRepository(string pconnectionString)
        {
            connectionString = pconnectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(connectionString);
        }

        public async Task<bool> deleteInvoice(int id)
        {
            var db = dbConnection();
            var sql = @"Delete Invoice where where InvoiceId=@id";
            var result = await db.ExecuteAsync(sql.ToString(), new { id = id });
            return result > 0;
        }

        public async Task<Invoice> getInvoiceDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT InvoiceId, ClientId, IssueDate, Paid FROM Invoice where InvoiceId=@InvoiceId ";
            return (Invoice)await db.QueryAsync<Invoice>(sql.ToString(), new { id});
        }

        public async Task<IEnumerable<Invoice>> getInvoiceByMonth(DateTime date)
        {
            var db = dbConnection();
            var sql = @"select InvoiceId, ClientId, IssueDate, Paid
                        FROM Invoice
                        where month([IssueDate])=month (@date) and year([IssueDate])=year(@date)";
            return await db.QueryAsync<Invoice>(sql.ToString(), new { date });
        }

        public async Task<bool> insertInvoice(Invoice invoice)
        {
            var db = dbConnection();
            var sql = @"Insert into Invoice( ClientId, IssueDate, Paid) 
                                    values (@ClientId, @IssueDate, @Paid) ";
            var result = await db.ExecuteAsync(sql.ToString(), new { invoice.ClientId, invoice.IssueDate, invoice.Paid });
            return result > 0;
        }

        public async Task<bool> updateInvoice(Invoice invoice)
        {
            var db = dbConnection();
            var sql = @"Update Invoice Set  ClientId=@ClientId, IssueDate=@IssueDate, Paid=@Paid
                       where InvoiceId=@InvoiceId";
            var result = await db.ExecuteAsync(sql.ToString(), new {invoice.ClientId, invoice.IssueDate, invoice.Paid, invoice.InvoiceId});
            return result > 0;
        }


       


    }
}
