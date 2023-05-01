using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Model
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public decimal Amount { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Total { get; set; }

        public InvoiceDetail() {
            product = new Product();
        }


    }
}
