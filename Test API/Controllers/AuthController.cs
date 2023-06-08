using Business;
using DAL;
using DAL.Classes;
using DAL.Interfaces;
using DocumentFormat.OpenXml.Spreadsheet;
using EmailService;
using Entities;
using Helpers;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Requests;
using System.Net.Mail;
using System.Security.Cryptography;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AuthController : ControllerBase
    {
        IUserRepository userRepository;
        private ApplicationDbContext context;
        readonly JwtService jwtService;
        readonly IUserService userService;
        readonly IEmailSender emailSender;
        private readonly EmailConfiguration _emailConfig;

        //  readonly HttpContextAccessor httpContextAccessor;
        public AuthController(IUserService userServ, ApplicationDbContext _context, JwtService _jwtService, IEmailSender _emailSender,EmailConfiguration emailConfiguration)
        {
            userService = userServ;
            context = _context;
            jwtService = _jwtService;
            emailSender = _emailSender;
            _emailConfig = emailConfiguration;
           
            
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register([FromQuery] UserRegisterDto request)
        {
            var user = userService.GetUsers().FirstOrDefault(x => x.email == request.email);
            if (user != null)
            {
                return NotFound("ce compte existe déjà");
            }
            userService.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            user = new User
            {
                email = request.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                adresse = request.adresse,
                nom = request.nom,
                prenom = request.prenom,
                telephone = request.telephone,
                CustomerId = string.Empty
            };
            userService.AddUser(user);
            var jwt = jwtService.Generate(user.idUser);
            //le frontend ne peut accéder au jwt, il doit seulement l'obtenir et l'envoyer vers le backend qui va le traiter
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromQuery] UserAuthDto request)
        {
            var user = userService.GetUsers().FirstOrDefault(x => x.email == request.email);
            if (user == null)
            {
                return BadRequest("ce compte n'existe pas");

            }
            if (!userService.VerifyPasswordHash(request.password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("mot de passe incorrect !");
            }
            var jwt = jwtService.Generate(user.idUser);
            //le frontend ne peut accéder au jwt, il doit seulement l'obtenir et l'envoyer vers le backend qui va le traiter
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return user;


        }
        [HttpGet]
        [Route("GetToken")]
        public IActionResult GetToken()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                return Ok(new { token = jwt });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }
        //cette méthode permet de retourner un utilisateur a partir du token
        [HttpGet]
        [Route("GetUserByToken")]
        public ActionResult<User> GetUserByToken()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = jwtService.Verify(jwt);
                int idUser = int.Parse(token.Issuer);
                User user = userService.GetUserById(idUser);
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "vous étes déconnecté"
            });

        }
        [HttpGet]
        [Route("sendEmail")]
        public async Task<IActionResult> Get([FromQuery] string emailto, string msg, string emailfrom)
        {

            var rng = new Random();
            var message = new Message(emailto, "Test email", msg, emailfrom);
            emailSender.SendEmail(message);

            return Ok("success");
        }
        [HttpPost]
        [Route("ContactUs")]
        public async Task<IActionResult> ContactUs([FromQuery] string name, string subject, string emailfrom,string password, string msg)
        {
            using (SmtpClient client = new SmtpClient())
             {
                 client.CheckCertificateRevocation = false;
                 client.Connect("smtp.gmail.com", 465);
                 client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(emailfrom, password);
                var message = new MimeMessage();
                 message.From.Add(new MailboxAddress( name, emailfrom));
                 message.To.Add(new MailboxAddress("Support", "eyaboukh@gmail.com"));
                 message.Subject = subject;
                 message.Body = new TextPart("plain")
                 {
                     Text = msg
                 };
                 client.Send(message);
             }
             return Ok("message sent successfully");
        }
       
        [HttpGet("Reset Password")]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset");
            }
            return RedirectToAction("ResetPassword", "Password", new ResetPasswordViewModel { Code = code });


        }

    }

}
