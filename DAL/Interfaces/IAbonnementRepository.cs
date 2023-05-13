using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAbonnementRepository
    {
        IEnumerable<Abonnement> GetAbonnements();
        Task<Abonnement> GetAbonnement(int? id);
        void AddAbonnement(Abonnement abonnement);
        Task<int> DeleteAbonnement(int id);

        Task UpdateAbonnement(Abonnement abonnement);
    }
}
