using Business;
using DAL;
using DAL.Classes;
using DAL.Interfaces;
using DocumentFormat.OpenXml.Spreadsheet;
using EmailService;
using Entities;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Requests;
using System.Security.Cryptography;


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
        
      //  readonly HttpContextAccessor httpContextAccessor;
        public AuthController(IUserService userServ, ApplicationDbContext _context, JwtService _jwtService, IEmailSender _emailSender)
        {
            userService = userServ;
            context = _context;
            jwtService = _jwtService;
            emailSender = _emailSender;
           
            
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register([FromQuery] UserRegisterDto request)
        {
            if (userService.GetUserByEmail(request.email) == null)
            {
                return NotFound("ce compte existe déjà");
            }
            userService.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                email = request.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                adresse = request.adresse,
                nom = request.nom,
                prenom = request.prenom,
                telephone = request.telephone,
            };
            userService.AddUser(user);

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
        //cette méthode permet de retourner un utilisateur a partir du token
        [HttpGet]
        [Route("GetUserByToken")]
        public IActionResult GetUserByToken()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = jwtService.Verify(jwt);
                int idUser = int.Parse(token.Issuer);
                var user = userService.GetUserById(idUser);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
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
        public async Task<IActionResult> Get([FromQuery] string[] email, string msg)
        {
            var rng = new Random();
            var message = new Message(email, "Test email", msg);
            emailSender.SendEmailAsync(message);

            return Ok("success");
        }
        [HttpPost("ForgotPassword")]
        /*public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (ModelState.IsValid)
            {

                var result = await userService.ForgotPassword(forgotPasswordDto.Email);
                if (!result.isValid)
                {
                    return Ok(new { Message = "Success" });
                }
                var callbackUrl = httpContextAccessor.AbsoluteUrl("", new { iduser = (string)result.Data["User"].idUser, code = (string)result.Data["code"] });
                var message = new Message(forgotPasswordDto.Email, "Reset Password", callbackUrl);
                await emailSender.SendEmailAsync(message);
                return Ok(new { Message = "Succes" });
            }
            return BadRequest("We have encountered an error");
        }*/
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
