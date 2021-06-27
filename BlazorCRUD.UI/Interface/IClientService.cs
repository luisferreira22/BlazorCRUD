using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interface
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> getAllClient();
        Task<Client> getClientDetails(int id);
        Task<bool> saveClient(Client client);
        Task<bool> deleteClient(int id);
    }
}
