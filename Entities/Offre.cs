using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Offre")]
    public class Offre
    {
        [Key]
        public int idOffre { get; set; }
        public int nombreHeure { get; set; }
        public float prixOffre { get; set; }
        public string contenu { get; set; }

        public Offre(int idOffre, int nombreHeure, float prixOffre, string contenu)
        {
            this.idOffre = idOffre;
            this.nombreHeure = nombreHeure;
            this.prixOffre = prixOffre;
            this.contenu = contenu;
        }

#pragma warning disable CS8618 // Le propriété 'contenu' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        public Offre()
#pragma warning restore CS8618 // Le propriété 'contenu' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le propriété comme nullable.
        {
        }
    }

}
