using BlazorCRUD.Data.Dapper.Repositories;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interface
{
    public class ClientService : IClientService
    {
        private readonly SqlConfiguration _configuration;
        private IClientRepository _IclientRepository;

        public ClientService(SqlConfiguration configuration) {
            _configuration = configuration;
            _IclientRepository = new ClientRepository(configuration.ConnectionString);
        }

        public Task<bool> deleteClient(int id)
        {
            return _IclientRepository.deleteClient(id);
        }

        public Task<IEnumerable<Client>> getAllClient()
        {
            return _IclientRepository.getAllClient();
        }

        public Task<Client> getClientDetails(int id)
        {
            return _IclientRepository.getClientDetails(id);
        }

        public Task<bool> saveClient(Client client)
        {
            if (client.ClientId == 0)
                return _IclientRepository.insertClient(client);
            else
                return _IclientRepository.updateClient(client);
        }
    }
}
