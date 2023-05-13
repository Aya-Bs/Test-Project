using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele_de_domaine
{
    public class Adresse
    {
        public int idPays { get; set; }
        public string nomPays { get; set; }

        public Adresse(int idPays, string nomPays)
        {
            this.idPays = idPays;
            this.nomPays = nomPays;
        }

#pragma warning disable CS8618 // Le propriété 'nomPays' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        public Adresse()
#pragma warning restore CS8618 // Le propriété 'nomPays' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        {
        }
    }
}
