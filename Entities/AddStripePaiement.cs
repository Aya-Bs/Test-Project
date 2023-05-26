using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddStripePaiement
{
        [ForeignKey("idUser")]
       public string CustomerId;

       public string ReceiptEmail;

        public string Description;

        public string Currency;

      public   long Amount;


        public AddStripePaiement(string customerId, string receiptEmail, string description, string currency, long amount)
        {
           
        }
    }
}
