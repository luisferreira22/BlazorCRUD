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
    public class InvoiceService : IInvoiceService
    {
        private readonly SqlConfiguration _configuration;
        private IInvoiceRepository _IinvoiceRepository;

        public InvoiceService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _IinvoiceRepository = new InvoiceRepository(configuration.ConnectionString);
        }

        public Task<bool> deleteInvoice(int id)
        {
            return _IinvoiceRepository.deleteInvoice(id);
        }

        public Task<IEnumerable<Invoice>> getInvoiceByMonth(DateTime month)
        {
            return _IinvoiceRepository.getInvoiceByMonth(month);
        }

        public Task<Invoice> getInvoiceDetails(int id)
        {
            return _IinvoiceRepository.getInvoiceDetails(id);
        }

        public Task<bool> saveInvoice(Invoice invoice)
        {
            if (invoice.InvoiceId == 0)
                return _IinvoiceRepository.insertInvoice(invoice);
            else
                return _IinvoiceRepository.updateInvoice(invoice);
        }
    }
}
