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
       /* [ForeignKey("adresseidPays")]
        public virtual Adresse adresse { get; set; }
        
        public int adresseidPays;*/
        //public CartePaiement carte { get; set; }


#pragma warning disable CS8618 // Le propriété 'Adresses' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        public User(int idUser, string nom, string prenom, string email, string password, long telephone)
        {
            this.idUser = idUser;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            SetPassword(password); // Hash and salt the password before storing it
            this.telephone = telephone;
            //this.adresse = adresse;
            //this.idPays = adresse.idPays;

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
    }
}