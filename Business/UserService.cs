using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserService : IUserService
    {
        public UserService() { }

        void IUserService.getUser(string email, string mdp)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserService.GetUsers()
        {
            throw new NotImplementedException();
        }

        void IUserService.inscrire(User user)
        {
            throw new NotImplementedException();
        }

        void IUserService.RemoveUser(int idUser)
        {
            throw new NotImplementedException();
        }

        void IUserService.UpdateUser(User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
