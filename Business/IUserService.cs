using System;
using Entities;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business
{
    internal interface IUserService
    { 

        IEnumerable<User> GetUsers(); 
        void inscrire(User user);
        void getUser(string email, string mdp);
        void UpdateUser(User updateUser);
        void RemoveUser(int idUser);

    }
}
