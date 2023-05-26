using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StripePaiement
{
        [ForeignKey("idUser")]
        public string CustomerId;
       public string ReceiptEmail;
        public string Description;
        public string Currency;
        public long Amount;
        public string PaymentId;
        public StripePaiement(string CustomerId, string ReceiptEmail, string Description, string Currency, long Amount, string PaymentId)
        {
            
        }

        
    }
}
