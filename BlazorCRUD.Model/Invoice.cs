using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Model
{
    public class Invoice
    {
        public int InvoiceId { set; get; }
        public int ClientId { get; set; }
        public DateTime IssueDate { get; set; }
        public bool Paid { get; set; }
         public Client client { get; set; }
        public List<InvoiceDetail> invoiceDetail { get; set; }

        public Invoice() {
            client = new Client();
            invoiceDetail = new List<InvoiceDetail>();
        }


    }
}
