using Entities;
using Microsoft.AspNetCore.Mvc;
using Modele_de_domaine;

using Business;
using Microsoft.EntityFrameworkCore;
using User = Entities.User;

using AutoMapper;
using DAL.Classes;
using DAL.Interfaces;

namespace Test_API.Controllers
{
    [ApiController]//annotation de notre controleur 
    [Route("/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;
        

        public UserController (IUserService userServ )
        {
            userService = userServ;
            
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<User> GetUsers()
        {
            return userService.GetUsers();
            
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = userService.GetUserById(id);
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
            userService.AddUser(user);
            return Created("successful", user);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            userService.UpdateUser(user);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateUserInfo")]
        /*public async Task<IActionResult> UpdateUserDetails([FromQuery] string nom, string prenom, int telephone , string adresse)
        {
            var user;//= userService.GetUserByEmail);
            if (user != null)
            {
                userService.UpdateUserDetails(nom, prenom, telephone, adresse);
                
            }
            return Ok("user updated");
            
        }*/


        [HttpDelete]
        [Route("DeleteUser")]
        public JsonResult DeleteUser(int id)
        {
            var result = userService.DeleteUser(id);
            return new JsonResult("Deleted Successfully");
        }
      


    }


}
