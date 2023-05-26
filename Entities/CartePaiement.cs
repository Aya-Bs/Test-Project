
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
   [Table("CartePaiement")]
    public class CartePaiement
    {
        [Key]
        public string name { get; set; }
        public string cardNumber { get; set; }
        public string expirationYear { get; set; }
        public string expirationMonth { get; set; }
        public string Cvc { get; set; }

        
        

        public CartePaiement (string name, string cardNumber, string expirationYear, string expirationMonth, string Cvc)
        {
            this.name = name;
            this.expirationYear = expirationYear;
            this.expirationMonth = expirationMonth;
            this.Cvc = Cvc;
            this.cardNumber = cardNumber;
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