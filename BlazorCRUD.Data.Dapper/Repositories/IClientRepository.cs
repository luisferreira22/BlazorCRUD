using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> getAllClient();
        Task<Client> getClientDetails(int id);
        Task<bool> insertClient(Client client);
        Task<bool> updateClient(Client client);
        Task<bool> deleteClient(int id);

    }
}
