using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public StripeController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }
        [HttpPost("customer/add")]
        public async Task<ActionResult<User>> AddStripeCustomer([FromBody] AddStripeCustomer customer,CancellationToken ct)
        {
            User createdCustomer = await _stripeService.AddStripeCustomerAsync(
                customer,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }
        [HttpPost("payment/add")]
        public async Task<ActionResult<StripePaiement>> AddStripePayment(
            [FromBody] AddStripePaiement payment,
            CancellationToken ct)
        {
            StripePaiement createdPayment = await _stripeService.AddStripePaymentAsync(
               payment,
               ct);

            return StatusCode(StatusCodes.Status200OK, createdPayment);
        }
    }

}

