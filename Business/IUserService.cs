using Entities;
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
        Task<User> GetUserById(int? id);
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUserByEmail(string email);

        Task UpdateUser(User user);
        

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
