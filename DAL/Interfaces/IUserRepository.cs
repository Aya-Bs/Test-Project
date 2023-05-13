using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace DAL.Interfaces
{
    public interface IUserRepository
    {

        IQueryable<User> GetUsers();

        // int? signifie que la valeur peut de int peut etre null
        Task<User> GetUser(int? id);
        Task AddUser(User user);
        Task<int> DeleteUser(int id);

        Task UpdateUser(User user);
        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordwsalt);
    }
}
