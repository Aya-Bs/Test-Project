using Business;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;
//using Microsoft.AspNetCore.Identity;



namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly StripeSettings _stripeSettings;
        private readonly ISubscriptionRepository _subscriberRepository;
      //  private readonly ISubscriptionService subscriptionService;
        private readonly IUserService _userService;


        //private readonly UserManager<User> _userManager;

        //UserManager<User> userManager
        //ISubscriptionRepository subscriberRepository,
        public PaymentController(IOptions<StripeSettings> stripeSettings,  IUserService userService)
        {
            //_userManager = userManager;
            StripeConfiguration.ApiKey = "sk_test_51NBE1QE0wr7UnfFe1Yhj2LucHi0QOuzhXAX9hxwuzo1HnEE98ulgy83am7s7oO6OegdlfeQSirwqwcWQ3cpsPnGe00G4qsueti";
            _stripeSettings = stripeSettings.Value;
           // _subscriberRepository = subscriberRepository;
            _userService = userService;
            

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
        // POST api/<PaymentsController>/webhook
        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                 json,
                 Request.Headers["Stripe-Signature"],
                 _stripeSettings.WHSecret
               );

                // Handle the event
                if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    //Do stuff
                    await addSubscriptionToDbAsync(subscription);
                }
                else if (stripeEvent.Type == Events.CustomerSubscriptionUpdated)
                {
                    var session = stripeEvent.Data.Object as Stripe.Subscription;

                    // Update Subsription
                    await updateSubscriptionAsync(session);
                }
                else if (stripeEvent.Type == Events.CustomerCreated)
                {
                    var customer = stripeEvent.Data.Object as Customer;
                    //Do Stuff
                     await addCustomerIdToUser(customer);
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return BadRequest();
            }
        }




        private async Task addCustomerIdToUser(Customer customer)
        {
            try
            {
                await _userService.UpdateCustomerId(customer);
                Console.WriteLine("Customer Id added to user");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to add customer id to user");
                Console.WriteLine(ex);
            }
        }

        private async Task addSubscriptionToDbAsync(Subscription subscription)
        {
            try
            {
                var subscriber = new Subscriber
                {
                    Id = subscription.Id,
                    CustomerId = subscription.CustomerId,
                    Status = "active",
                    CurrentPeriodEnd = subscription.CurrentPeriodEnd
                };
                await _subscriberRepository.CreateAsync(subscriber);

                //You can send the new subscriber an email welcoming the new subscriber
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Unable to add new subscriber to Database");
                Console.WriteLine(ex.Message);
            }
        }
        private async Task updateSubscriptionAsync(Subscription subscription)
        {
            try
            {
                var subscriptionFromDb = await _subscriberRepository.GetByIdAsync(subscription.Id);
                if (subscriptionFromDb != null)
                {
                    subscriptionFromDb.Status = subscription.Status;
                    subscriptionFromDb.CurrentPeriodEnd = subscription.CurrentPeriodEnd;
                    await _subscriberRepository.UpdateAsync(subscriptionFromDb);
                    Console.WriteLine("Subscription Updated");
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("Unable to update subscription");

            }
        }
    }




} 

        

        //[Authorize]

       // [HttpPost("customer-portal")]
        /*  public async Task<IActionResult> CustomerPortal([FromBody] CustomerPortalRequest req)

          {
               try
               {

                   ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
                   var claim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
                   var userFromDb = await _userManager.FindByNameAsync(claim.Value);

                   if (userFromDb == null)
                   {
                       return BadRequest();
                   }


                   var options = new Stripe.BillingPortal.SessionCreateOptions
                   {
                       Customer = userFromDb.CustomerId,
                       ReturnUrl = req.ReturnUrl,
                   };
                   var service = new Stripe.BillingPortal.SessionService();
                   var session = await service.CreateAsync(options);

                   return Ok(new {url =  session.Url });
               }
               catch (StripeException e)
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

           }}*/


   


