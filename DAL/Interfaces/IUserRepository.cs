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

        IEnumerable<User> GetUsers();

        // int? signifie que la valeur peut de int peut etre null
     User GetUserById(int? id);
        Task AddUser(User user);
        Task DeleteUser(int id);
       Task<User> GetUserByEmail(string email);
        public Task UpdateUserDetails(string nom, string prenom, int telephone, string adresse);
        Task UpdateUser(User user);
        
    }
}
