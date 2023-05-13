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
      


    }


}
