using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AbonnementService : IAbonnementService
    {
        private readonly IAbonnementRepository abonnementRepository;
        public AbonnementService(IAbonnementRepository abonnementRepo)
        {
            abonnementRepository = abonnementRepo;
        }
        public void AddAbonnement(Abonnement abonnement)
        {
            abonnementRepository.AddAbonnement(abonnement);
        }

        public Task DeleteAbonnement(int id)
        {
           return abonnementRepository.DeleteAbonnement(id);
        }

        public Task<Abonnement> GetAbonnement(int? id)
        {
            return abonnementRepository.GetAbonnement(id);
        }

        public List<Abonnement> GetAbonnementByContenu(string word)
        {
            List<Abonnement> abs = new List<Abonnement>();
            foreach (Abonnement ab in abonnementRepository.GetAbonnements())
            {
                if (ab.contenu.Contains(word))
                    abs.Add(ab);

            }
            return abs;
        }

        public IEnumerable<Abonnement> GetAbonnements()
        {
            return abonnementRepository.GetAbonnements();
        }

        public Task UpdateAbonnement(Abonnement abonnement)
        {
            return abonnementRepository.UpdateAbonnement(abonnement);
        }

       
    }
}
