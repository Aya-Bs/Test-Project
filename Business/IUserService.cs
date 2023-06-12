using Entities;
using Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int? id);
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUserByEmail(string email);

        Task UpdateUser(User user);
       // User UpdateUserDetails(string nom, string prenom, int telephone, string adresse);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        //public Task<ResponseObject> ForgotPassword(string email);
        //public Task<ResponseObject> ResetPassword(ResetPasswordViewModel model);

    }
}
