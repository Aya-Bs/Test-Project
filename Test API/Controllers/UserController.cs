using Entities;
using Microsoft.AspNetCore.Mvc;
using Modele_de_domaine;

using Business;
using Microsoft.EntityFrameworkCore;
using User = Entities.User;
using Adresse = Entities.Adresse;
using AutoMapper;
using DAL.Classes;
using DAL.Interfaces;

namespace Test_API.Controllers
{
    [ApiController]//annotation de notre controleur 
    [Route("/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper mapper;

        public UserController (IUserRepository userRepository,IMapper mapper )
        {
            _userRepository = userRepository;
            this.mapper=mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<User> GetUsers()
        {
            return (IEnumerable<User>)_userRepository.GetUsers();
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            _userRepository.AddUser(user);
            return Created("successful", user);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public JsonResult DeleteUser(int id)
        {
            var result = _userRepository.DeleteUser(id);
            return new JsonResult("Deleted Successfully");
        }
      

        

        /*
        //authentification 
        [HttpPost]
        [Route("Authentificate")]
        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetUsers().SingleOrDefaultAsync(u => u.email == email);

            if (user == null  || VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            // authentication successful
            return user;
        }
        */
        /*[HttpPost]
        [Route("Authentificate")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetUsers().FirstOrDefaultAsync(u => u.email == email );

            if (user == null || !_userRepository.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized();
            }

            // authentication successful
            return Ok(user);
        }*/





        /*
        //authentification 
        [HttpPost]
        [Route("Authentificate")]
       public async Task<IActionResult> Authentificate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _userRepository.GetUsers().FirstOrDefaultAsync(x => x.email == userObj.email && x.password == userObj.password);
            if (user == null)
                return NotFound(new { Message = "User Not Found" });

            return Ok(new { Message = "login success!" });
        }
        */
        //register


    }


}
