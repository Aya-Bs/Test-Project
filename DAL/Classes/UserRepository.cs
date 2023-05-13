using DAL.Interfaces;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
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
        AdresseRepository adresseRepository;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        //la méthode AddAsync est appelée sur un objet de type IQueryable<User> retourné par la méthode GetUsers
        //de votre interface IUserRepository. La méthode AddAsync n'est pas une méthode définie
        //sur l'interface IQueryable<T> ou sur les types retournés par celle-ci, comme IUserRepository le spécifie.
        public async Task<int> DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.idUser == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);

            }
            return _dbContext.SaveChanges();
        }


        public IQueryable<User> GetUsers()
        {
            return _dbContext.Users.Select(u => new User
            {
                idUser = u.idUser,
                nom = u.nom,
                prenom = u.prenom,
                email = u.email,
                telephone = u.telephone,
                PasswordHash = u.PasswordHash,
                PasswordSalt = u.PasswordSalt

            }) ;
        }
        //private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
       

        /* public IQueryable<User> GetUsers()
         {
             return  _dbContext.Users.Include(user => user.adresse).ToList().AsQueryable();//result;
         }*/
        public async Task<User> GetUser(int? id)
        {
            
            return _dbContext.Users.Find(id);
            
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void CreatePasswordHash( string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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

