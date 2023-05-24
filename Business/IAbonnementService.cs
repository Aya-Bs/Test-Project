using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IAbonnementService
    {
        IEnumerable<Abonnement> GetAbonnements();
        Task<Abonnement> GetAbonnement(int? id);
        void AddAbonnement(Abonnement abonnement);
        Task DeleteAbonnement(int id);

        Task UpdateAbonnement(Abonnement abonnement);
        List<Abonnement> GetAbonnementByContenu(string word);
    }
}
