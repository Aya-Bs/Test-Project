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
        /*public async Task<ResponseObject> ForgotPassword(string email)
        {
            ResponseObject responseObject = new ResponseObject();
            var user = await userManager.FindByEmailAsync(email);
            try
            {
                if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                {
                    responseObject.Message = "Failed";
                    responseObject.isValid = false;
                    responseObject.Data = null;
                    return responseObject;
                }
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                responseObject.Message = "Success";
                responseObject.isValid = true;
                var dynamicProperties = new Dictionary<string, object> { ["Code"] = code, ["User"] = user };
                responseObject.Data = dynamicProperties;
                return responseObject;
            }
            catch (Exception ex)
            {

                Log.Error("An error occured at Forgot Password {Error} {StackTrace} {Source}");
                Log.Error(ex.Message);
                Log.Error(ex.StackTrace);
                
                Log.Error(ex.Source);
                responseObject.Message = "Error";
                responseObject.isValid = false;
                responseObject.Data = null;
                return responseObject;

            }
        }

        public async Task<ResponseObject> ResetPassword(ResetPasswordViewModel model)
        {
            ResponseObject responseObject = new ResponseObject();
            
            try
            {
                var user = await userManager.FindByEmailAsync(model.email);
                if(user == null)
                {
                    responseObject.Message = "Failed";
                    responseObject.isValid = false;
                    responseObject.Data = null;
                    return responseObject;
                }
                var result = await userManager.ResetPasswordAsync(user, model.Code, model.password);
                if (result.Succeeded)
                {
                    
                    this.CreatePasswordHash(model.password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    userRepository.UpdateUser(user);
                    responseObject.Message = "Success";
                    responseObject.isValid = true;
                    responseObject.Data = null;
                   
                } return responseObject;

            }
            catch(Exception e)
            {
                Log.Error("An error occured at Forgot Password {Error} {StackTrace} {Source}");
                Log.Error(e.Message);
                Log.Error(e.StackTrace);

                Log.Error(e.Source);
                responseObject.Message = "Error";
                responseObject.isValid = false;
                responseObject.Data = null;
                return responseObject;
            }
            
            
        }*/
    }
}
