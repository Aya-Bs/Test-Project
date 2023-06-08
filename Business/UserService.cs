using DAL.Interfaces;
using DocumentFormat.OpenXml.Office2016.Excel;
using Entities;

using Microsoft.AspNetCore.Identity;
using NLog.Fluent;
using Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Stripe;

namespace Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        
        
        public UserService(IUserRepository userRepo)
        {
            userRepository = userRepo;
           
           
        }
        public async Task AddUser(User user)
        {
            await userRepository.AddUser(user);
        }

       
       public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using (var hmac = new HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }
            
        

        public async Task DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
            

        }

        public async Task<User> GetUserByEmail(string email)
        {
           return await userRepository.GetUserByEmail(email);
            
                
            
        }

        public User GetUserById(int? id)
        { 
           var user= userRepository.GetUserById(id);
            return user;
        }


        public IEnumerable<User> GetUsers()
        {
            
                return userRepository.GetUsers();
                
        }

        public Task UpdateUser(User user)
        {
           return userRepository.UpdateUser(user);
        }

        /*public User UpdateUserDetails(string nom, string prenom, int telephone, string adresse)
        {

            User user = new User {
                user.idUser = user.idUser,
            user.nom = nom,
            user.prenom = prenom,
            user.email = user.email;
            user.PasswordHash = user.PasswordHash;
            user.PasswordSalt = user.PasswordSalt;
            user.telephone = telephone;
            user.adresse = adresse;
            userRepository.UpdateUser(user);
            return user;
        };
        }*/
        /* public async Task UpdateCustomerId(Customer customer)
          {
              var user = await userRepository.GetUserByEmail(customer.Email);
              if (user != null)
              {
                  user.idUser = user.idUser;
                  user.nom = user.nom;
                  user.prenom = user.prenom;
                  user.adresse = user.adresse;
                  user.telephone = user.telephone;
                  user.PasswordHash = user.PasswordHash;
                  user.PasswordSalt = user.PasswordSalt;
                  user.CustomerId = customer.Id;
              }
              userRepository.UpdateUser(user);
              return user;
          }*/

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null || storedHash == null || storedSalt == null)
            {
                Console.WriteLine("empty");
                return false;
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }


        }
        
    }
}
