using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public interface IInvoiceDetailRepository
    {
        Task<InvoiceDetail> getInvoiceDetails(int id);
        Task<IEnumerable<InvoiceDetail>> getInvoiceDetailsByInvoiceId(int id);
        Task<bool> insertInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<bool> updateInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<bool> deleteInvoiceDetail(int id);
        Task<bool> deleteInvoiceDetailByInvoiceId(int id);

    }
}
