using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interface
{
    public interface IAuthenticationUserService
    {
        Task<bool> checkAuthenticationUser(AuthenticationUser authenticationUser);
    }
}



