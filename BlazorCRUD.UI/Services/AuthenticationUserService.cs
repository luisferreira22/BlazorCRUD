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
    public class AuthenticationUserService : IAuthenticationUserService
    {
        private readonly SqlConfiguration _configuration;
        private IAuthenticationUserRespository _IAuthenticationUserRepository;

        public AuthenticationUserService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _IAuthenticationUserRepository = new AuthenticationUserRepository(configuration.ConnectionString);
        }
        public Task<bool> checkAuthenticationUser(AuthenticationUser authenticationUser)
        {
            return _IAuthenticationUserRepository.checkAuthenticationUser(authenticationUser);
        }

    }
}
