using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public interface IAuthenticationUserRespository
    {
        Task<bool> checkAuthenticationUser(AuthenticationUser authenticationUser);
    }
}
