using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IStripeService
    {
        Task<User> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePaiement> AddStripePaymentAsync(AddStripePaiement payment, CancellationToken ct);
    }
}
