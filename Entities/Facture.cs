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
    [Table("Facture")]
    public class Facture
    {
        [Key]
        public int idFacture { get; set; }
        public DateTime dateOperation { get; set; }
       

        public string statutPaiement { get; set; }
        public float prixTotal { get; set; }

        //navigation property
        [ForeignKey("carteidCvvCvc")]
        public CartePaiement carte { get; set; }
        [ForeignKey("idUser")]
        public User user;
        [ForeignKey("idAbonnement")]

        public Abonnement abonnement;
        

        public Facture(int idFacture, DateTime dateOperation, int idCarte, string statutPaiement, float prixTotal, CartePaiement carte, User user, Abonnement abonnement)
        {
            this.idFacture = idFacture;
            this.dateOperation = dateOperation;
            this.statutPaiement = statutPaiement;
            this.prixTotal = prixTotal;
            this.carte = carte;
            this.abonnement = abonnement;
            this.user = user;   

        }

        public Facture()
        {
        }

    }
}
