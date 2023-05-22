using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Panier
{
        public int idPanier;
        public float prixAchat;
        public int promoCode = 0;
        public int idAbonnement;
        public int idUser;
        public User user;
        public Abonnement abonnement;

}
}
