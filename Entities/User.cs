using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities
{
    [Table("User")]
    public class User
    {
       

        [Key]
        public int idUser { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        //n'affiche pas le mdp

        [JsonIgnore] public byte[] PasswordHash { get; set; }

        [JsonIgnore] public byte[] PasswordSalt { get; set; }
        public long telephone { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }

        public string CustomerId { get; set; }
        

#pragma warning disable CS8618 // Le propriété 'Adresses' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        public User(int idUser, string nom, string prenom, string email, byte[] passwordsalt, byte[] passwordhash, long telephone,string adresse,string CustomerId)
        {
            this.idUser = idUser;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.PasswordHash = passwordhash;
            this.PasswordSalt = passwordsalt;
            this.adresse = adresse;
            this.telephone = telephone;
            this.CustomerId = CustomerId;


        }

        private void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                using (var hmac = new HMACSHA512())
                {
                    PasswordSalt = hmac.Key;
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
            }
        }
        public void setPassHash(byte[] passHash)
        {
            this.PasswordHash = passHash;
        }
        public void setPassSalt(byte[] passSalt)
        {
            this.PasswordSalt = passSalt;
        }

        /*  private void SetPassword(string password)
          {
              using (var hmac = new HMACSHA512())
              {
                  PasswordSalt = hmac.Key;
                  PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
              }
          }*/
        /*public bool VerifyPassword(string password)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != PasswordHash[i])
                        return false;
                }
                return true;
            }
        }*/
        public User()
        {
        }

        public User(string nom, string prenom, int telephone, string adresse)
        {
            this.idUser = idUser;
            
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.email = email;
            this.CustomerId = CustomerId;
            this.PasswordHash = PasswordHash;
            this.PasswordSalt = PasswordSalt;
        }
    }
}