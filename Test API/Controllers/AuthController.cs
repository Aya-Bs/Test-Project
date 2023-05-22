using DAL;
using DAL.Classes;
using DAL.Interfaces;
using Entities;
using Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
       readonly IUserRepository userRepository;
        private ApplicationDbContext context;
        readonly JwtService jwtService;
        public AuthController(IUserRepository userRepo, ApplicationDbContext _context, JwtService _jwtService)
        {
            userRepository = userRepo;
            context = _context;
            jwtService = _jwtService;
        }
       [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register(string nom,string prenom,long telephone,string adresse, [FromQuery] UserRegisterDto request)
        {
            if (userRepository.GetUsers().Any(u => u.email == request.email))
            {
                return NotFound("ce compte existe déjà");
            }
            userRepository.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                email = request.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                adresse = adresse,
                nom = nom,
                prenom = prenom,
                telephone = telephone,
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>>Login ([FromQuery]UserAuthDto request)
        {
            var user = await userRepository.GetUsers().FirstOrDefaultAsync(x => x.email == request.email);
            if (user == null)
            {
                return BadRequest("ce compte n'existe pas");

             }
            if (!(userRepository.VerifyPasswordHash(request.password, user.PasswordHash, user.PasswordSalt)))
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
                var user = userRepository.GetUser(idUser);
                return Ok(user);
            }catch(Exception e)
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
       

    }
}
