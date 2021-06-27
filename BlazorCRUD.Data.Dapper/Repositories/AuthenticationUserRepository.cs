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
    public class AuthenticationUserRepository : IAuthenticationUserRespository
    {
        private string connectionString;
        public AuthenticationUserRepository(string pconnectionString)
        {
            connectionString = pconnectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(connectionString);
        }


        public async Task<bool> checkAuthenticationUser(AuthenticationUser authenticationUser)
        {
            var db = dbConnection();
            var sql = @"SELECT UserId FROM AccesUser where UserName=@UserName and Password=@Password";
            var result = await db.QueryFirstOrDefaultAsync<int>(sql.ToString(), (authenticationUser.UserName, authenticationUser.Password));
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
