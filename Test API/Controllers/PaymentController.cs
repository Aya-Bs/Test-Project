using Entities;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;


namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController()
        {

            StripeConfiguration.ApiKey = "sk_test_51NBE1QE0wr7UnfFe1Yhj2LucHi0QOuzhXAX9hxwuzo1HnEE98ulgy83am7s7oO6OegdlfeQSirwqwcWQ3cpsPnGe00G4qsueti";

        }
        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest req)
        {
            var options = new SessionCreateOptions
            {
                SuccessUrl = "http://localhost:4200/success",
                CancelUrl = "http://localhost:4200/failure",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = req.PriceId,
                        Quantity = 1,
                    },
                },

            }; var service = new SessionService();
            try
            {
                var session = await service.CreateAsync(options);
                return Ok(new CreateCheckoutSessionResponse
                {
                    SessionId = session.Id,
                });
            }
            catch (StripeException e)
            {
                {
                    Console.WriteLine(e.StripeError.Message);
                    return BadRequest(new ErrorResponse
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            Message = e.StripeError.Message,
                        }
                    });
                }
            }


        }
    }
}

