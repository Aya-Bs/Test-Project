using DAL;
using DAL.Classes;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Requests;
using System.Security.Cryptography;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       readonly IUserRepository userRepository;
        readonly ApplicationDbContext context;
        public AuthController(IUserRepository userRepo, ApplicationDbContext _context)
        {
            userRepository = userRepo;
            context = _context;
        }
       [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register(string nom,string prenom,long telephone, [FromQuery] UserRegisterDto request)
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
                nom = nom,
                prenom = prenom,
                telephone = telephone,
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Ok("vous étes inscrit");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>>Login ([FromQuery]UserAuthDto request)
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
            return ("salut salut !");
                
            
            
            
        }
       

    }
}
