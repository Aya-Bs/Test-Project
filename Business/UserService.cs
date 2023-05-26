using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


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

        public  Task<User> GetUserByEmail(string email)
        {
           return userRepository.GetUserByEmail(email);
            //var user = userRepository.GetUsers().FirstOrDefault(x => x.email == email);
           // return null;
                
            
        }

        public Task<User> GetUserById(int? id)
        {
            return userRepository.GetUserById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            
                return userRepository.GetUsers();
                
        }

        public Task UpdateUser(User user)
        {
           return userRepository.UpdateUser(user);
        }

        public Task UpdateUserDetails(string nom, string prenom,  int telephone, string adresse)
        {
            return userRepository.UpdateUserDetails(nom, prenom, telephone, adresse);
        }

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
