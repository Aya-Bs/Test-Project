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
        public string nomAb { get; set; }
        public float prixAbonnement { get; set; }
        public int nombreAchat { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public string contenu { get; set; }
        public string description { get; set; }



        public Abonnement(int idAbonnement, float prixAbonnement, int nombreAchat, bool isActive, DateTime dateDebut, DateTime dateFin)
        {
            this.idAbonnement = idAbonnement;
            this.prixAbonnement = prixAbonnement;
            this.nombreAchat = nombreAchat;
            this.isActive = isActive;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            
        }


        public Abonnement()
        {
        }

        /*public Boolean isActiveTime(DateTime dateDebut, DateTime dateFin)
        {
            int ts = DateTime.Compare(DateTime.Now , dateFin);
            if (ts > 0)
            {
                isActive = false;
            }
            return false;

        }*/
       
       


    }
    }

