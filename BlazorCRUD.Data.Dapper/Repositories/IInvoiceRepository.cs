using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> getInvoiceDetails(int id);
        Task<bool> insertInvoice(Invoice invoice);
        Task<bool> updateInvoice(Invoice invoice);
        Task<bool> deleteInvoice(int id);

        Task<IEnumerable<Invoice>> getInvoiceByMonth(DateTime month);
    }
}
