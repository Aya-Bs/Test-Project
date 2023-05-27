using DAL.Interfaces;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _dbContext;
        

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();

          
        }
        public async Task<User> GetUserById(int? id)
        {

            return _dbContext.Users.Find(id);

        }

        //la méthode AddAsync est appelée sur un objet de type IQueryable<User> retourné par la méthode GetUsers
        //de votre interface IUserRepository. La méthode AddAsync n'est pas une méthode définie
        //sur l'interface IQueryable<T> ou sur les types retournés par celle-ci, comme IUserRepository le spécifie.
        public async Task DeleteUser(int id)
        {
            
            var user =  _dbContext.Users.Find(id);
             
            if (user!=null)
            {
                _dbContext.Remove(user);
            }
           await _dbContext.SaveChangesAsync();
        }


        
        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<User> GetUserByEmail(string email)
        {
            return _dbContext.Users.Find(email);
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
        public async Task UpdateUserDetails(string nom, string prenom,  int telephone, string adresse, string email)
        {
            var user = _dbContext.Users.FirstOrDefault(x=>x.email==email);
            user = new User(nom, prenom, telephone, adresse);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public async Task UpdateUserDetails(string nom, string prenom)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.UpdateUserDetails(string nom, string prenom, int telephone, string adresse)
        {
            throw new NotImplementedException();
        }
    }
}

