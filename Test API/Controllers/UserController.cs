using Entities;
using Microsoft.AspNetCore.Mvc;
using Modele_de_domaine;

using Business;
using Microsoft.EntityFrameworkCore;
using User = Entities.User;

using AutoMapper;
using DAL.Classes;
using DAL.Interfaces;
using Helpers;
using DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;

namespace Test_API.Controllers
{
    [ApiController]//annotation de notre controleur 
    [Route("/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;
        readonly JwtService jwtService;
        private readonly ApplicationDbContext dbContext;

        public UserController(IUserService userServ, JwtService jwtServ, ApplicationDbContext applicationDb)
        {
            userService = userServ;
            jwtService = jwtServ;
            dbContext = applicationDb;

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
        [HttpGet]
        [Route("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = userService.GetUserByEmail(email);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();


        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            userService.AddUser(user);
            return Created("successful", user);
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
        [HttpPut]
        [Route("UpdateUserInfo")]
        public ActionResult<User> UpdateUserDetails([FromQuery] string nom, string prenom, int telephone, string adresse)
        {
            var userResult = GetUserByToken();
                if (userResult == null)
                {
                    return Unauthorized();
                }
                    var existingUser = userResult.Value;
                    if (existingUser == null)
                    {
                        return Unauthorized();
                    }

                    var updatedUser = new User
                    {
                        idUser = existingUser.idUser,
                        nom = nom,
                        prenom = prenom,
                        email = existingUser.email,
                        PasswordHash = existingUser.PasswordHash,
                        PasswordSalt = existingUser.PasswordSalt,
                        telephone = telephone,
                        adresse = adresse,
                        CustomerId = existingUser.CustomerId
                    };
                    dbContext.Users.Update(updatedUser);
                    // dbContext.Entry(existingUser).CurrentValues.SetValues(updatedUser);
                    dbContext.SaveChanges();

                    return updatedUser;
                
               
            }
        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<User> UpdateUser([FromQuery]string email, string nom, string prenom, int telephone, string adresse)
        {
            var userResult = userService.GetUserByEmail(email);

            if (userResult == null)
            {
                return Unauthorized();
            }
            var existingUser = userResult.Result;
            if (existingUser == null)
            {
                return Unauthorized();
            }

            var updatedUser = new User
            {
                idUser = existingUser.idUser,
                nom = nom,
                prenom = prenom,
                email = existingUser.email,
                PasswordHash = existingUser.PasswordHash,
                PasswordSalt = existingUser.PasswordSalt,
                telephone = telephone,
                adresse = adresse,
                CustomerId = existingUser.CustomerId
            };
            dbContext.Users.Update(updatedUser);
            // dbContext.Entry(existingUser).CurrentValues.SetValues(updatedUser);
            dbContext.SaveChanges();

            return updatedUser;


        }


        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(string email)
        {
            var userResult = userService.GetUserByEmail(email);

            try
            {
                var user = userResult.Result;

                // Call the userService to delete the user
                userService.DeleteUser(user.idUser);

                // Delete the JWT token from the response cookies
                Response.Cookies.Delete("jwt");

                return Ok("Deleted Successfully");
            }
            catch (Exception e)
            {
                // You can handle the error scenario here
                return StatusCode(500, $"An error occurred while deleting the user: {e.Message}");
            }
        }
    

    }


}
