using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddStripeCustomer
{
        public string nom { get; set; }
       
        public string email { get; set; }
        public CartePaiement carte { get; set; }
        public AddStripeCustomer()
        {
            
        }
    }
}
