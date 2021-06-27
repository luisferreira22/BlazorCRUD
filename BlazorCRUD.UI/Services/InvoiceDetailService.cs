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
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly SqlConfiguration _configuration;
        private IInvoiceDetailRepository _IinvoiceDetailRepository;

        public InvoiceDetailService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _IinvoiceDetailRepository = new InvoiceDetailRepository(configuration.ConnectionString);
        }

        public Task<bool> deleteInvoiceDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteInvoiceDetailByInvoiceId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetail> getInvoiceDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceDetail>> getInvoiceDetailsByInvoiceId(int id)
        {
            return _IinvoiceDetailRepository.getInvoiceDetailsByInvoiceId(id);
        }

        public Task<bool> insertInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            throw new NotImplementedException();
        }
    }
}
