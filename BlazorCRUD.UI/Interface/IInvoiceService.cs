using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.UI.Interface
{
    public interface IInvoiceService
    {
        Task<Invoice> getInvoiceDetails(int id);
        Task<bool> saveInvoice(Invoice invoice);
        Task<bool> deleteInvoice(int id);
        Task<IEnumerable<Invoice>> getInvoiceByMonth(DateTime month);

    }
}
