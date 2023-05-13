namespace Modele_de_domaine
{
    public class User
    {
        public int idUser { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string password { get; set; }
        public long telephone { get; set; }
        public string email { get; set; }

        //navigation properties
        public Adresse adresse { get; set; }
        public int idPays { get; set; } 
         
#pragma warning disable CS8618 // Le propriété 'email' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        public User(int idUser, string nom, string prenom, string email, string password, long telephone, int idPays) { 
            this.idUser = idUser;   
            this.nom = nom;
            this.prenom = prenom;   
            this.password = password;   
            this.telephone = telephone; 
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
            this.idPays= adresse.idPays;
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
        
        }
#pragma warning restore CS8618 // Le propriété 'email' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning disable CS8618 // Le propriété 'email' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning disable CS8618 // Le propriété 'password' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning disable CS8618 // Le propriété 'adresse' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning disable CS8618 // Le propriété 'prenom' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning disable CS8618 // Le propriété 'nom' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        public User()
#pragma warning restore CS8618 // Le propriété 'nom' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning restore CS8618 // Le propriété 'prenom' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning restore CS8618 // Le propriété 'adresse' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning restore CS8618 // Le propriété 'password' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
#pragma warning restore CS8618 // Le propriété 'email' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        {
        }





    }
}