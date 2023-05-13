using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities
{
    [Table("Abonnement")]
    public class Abonnement 
    {

        [Key]
        public int idAbonnement { get; set; }
        public float prixAbonnement { get; set; }
        public string typeAbonnement { get; set; }
        public int nombreAchat { get; set; }
        public bool isActive { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public string categorie { get; set; }
        [ForeignKey("idOffre")]
        public Offre offre;
        
        

        public Abonnement(int idAbonnement, float prixAbonnement, string typeAbonnement, int nombreAchat, bool isActive, DateTime dateDebut, DateTime dateFin, string categorie, Offre offre)
        {
            this.idAbonnement = idAbonnement;
            this.prixAbonnement = prixAbonnement;
            this.typeAbonnement = typeAbonnement;
            this.nombreAchat = nombreAchat;
            this.isActive = isActive;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.categorie = categorie;
            this.offre = offre;

        }


        public Abonnement()
        {
        }

        public Boolean isExpired(DateTime dateDebut, DateTime dateFin)
        {
            return true;
        }
        public string type (DateTime dateDebut, DateTime dateFin)
        {
            /*TimeSpan ts = dateFin - dateDebut;
            if (ts <= 31)
            {
                typeAbonnement = "mensuel";
            }*/
            return null;
        }


    }
    }

