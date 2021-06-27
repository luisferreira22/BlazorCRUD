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
    public class ClientRepository : IClientRepository
    {
        private string connectionString;
        public ClientRepository(string pconnectionString)
        {
            connectionString = pconnectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(connectionString);
        }

        public async Task<bool> deleteClient(int id)
        {
            var db = dbConnection();
            var sql = @"Delete Cient where where ClientId=@id";
            var result = await db.ExecuteAsync(sql.ToString(), new {id=id});
            return result > 0;
        }

        public async Task<IEnumerable<Client>> getAllClient()
        {
            var db = dbConnection();
            var sql = @"SELECT ClientId, Name, Address, BornDate, PhoneNumber, Email, Picture  FROM Client";
            return await db.QueryAsync<Client>(sql.ToString(), new { });
        }

        public async Task<Client> getClientDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT ClientId, Name, Address, BornDate, PhoneNumber, Email, Picture  FROM Client where ClientId=@id";
            return await db.QueryFirstOrDefaultAsync<Client>(sql.ToString(), new {id});
        }

        public async Task<bool> insertClient(Client client)
        {
            var db = dbConnection();
            var sql = @"Insert into Client( Name, Address, BornDate, PhoneNumber, Email, Picture) 
                                    values (@Name, @Address, @BornDate, @PhoneNumber, @Email, @Picture) ";
            var result = await db.ExecuteAsync(sql.ToString(), new { client.Name, client.Address, client.BornDate, client.PhoneNumber,client.Picture, client.Email });
            return result > 0;
        }

        public async Task<bool> updateClient(Client client)
        {
            var db = dbConnection();
            var sql = @"Update Client Set  Name=@Name, Address=@Address, BornDate=@BornDate, PhoneNumber=@PhoneNumber, Email=@Email, Picture=@Picture
                       where ClientId=@ClientId";
            var result = await db.ExecuteAsync(sql.ToString(), new { client.Name, client.Address, client.BornDate, client.PhoneNumber, client.Email,client.Picture,client.ClientId });
            return result > 0;
        }
    }
}
