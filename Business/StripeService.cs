using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using Entities;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StripeService : IStripeService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        public StripeService(ChargeService chargeService, CustomerService customerService,TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;

        }



        public async Task<User> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct)
        {
            // Set Stripe Token options based on customer data
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.nom,
                    Number = customer.carte.cardNumber,
                    ExpYear = customer.carte.expirationYear,
                    ExpMonth = customer.carte.expirationMonth,
                    Cvc = customer.carte.Cvc
                }
            };
            // Create new Stripe Token
            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);
            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.nom,
                Email = customer.email,
                Source = stripeToken.Id
            };
            // Create customer at Stripe
            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);
            // Return the created customer at stripe
            return new User(createdCustomer.Name,createdCustomer.Email,createdCustomer.Id);

        }

        

        public async Task<StripePaiement> AddStripePaymentAsync(AddStripePaiement payment, CancellationToken ct)
        {
            // Set the options for the payment we would like to create at Stripe
        ChargeCreateOptions paymentOptions = new ChargeCreateOptions
    {
        Customer = payment.CustomerId,
        ReceiptEmail = payment.ReceiptEmail,
        Description = payment.Description,
        Currency = payment.Currency,
        Amount = payment.Amount
    };

            // Create the payment
            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);
            // Return the payment to requesting method
            return new StripePaiement(
                createdPayment.CustomerId,
                createdPayment.ReceiptEmail,
                createdPayment.Description,
                createdPayment.Currency,
                createdPayment.Amount,
                createdPayment.Id);
        }

       
    }

    
    
}
