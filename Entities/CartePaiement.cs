
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
   [Table("CartePaiement")]
    public class CartePaiement
    {
        [Key]
        public int idCvvCvc { get; set; }
        public string typeCarte { get; set; }
        public DateTime dateExpiration { get; set; }

        //navigation property 
        public User user;
        public int idUser;

        public CartePaiement (int idCvvCvc, string typeCarte, DateTime dateExpiration, int idUser,User user)
        {
            this.idCvvCvc = idCvvCvc;
            this.typeCarte = typeCarte;
            this.dateExpiration = dateExpiration;
            this.idUser = idUser;
            this.user = user;
        }

#pragma warning disable CS8618 // Le propri�t� 'typeCarte' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de d�clarer le propri�t� comme nullable.
#pragma warning disable CS8618 // Le champ 'user' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de d�clarer le champ comme nullable.
        public CartePaiement()
#pragma warning restore CS8618 // Le champ 'user' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de d�clarer le champ comme nullable.
#pragma warning restore CS8618 // Le propri�t� 'typeCarte' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de d�clarer le propri�t� comme nullable.
        {
        }
    }
}