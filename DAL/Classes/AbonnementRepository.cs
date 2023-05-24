using DAL.Interfaces;
using DocumentFormat.OpenXml.Drawing;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class AbonnementRepository : IAbonnementRepository
    {
        public ApplicationDbContext _dbContext;
        public AbonnementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IEnumerable<Abonnement> GetAbonnements()
        {
            return _dbContext.Abonnements.ToList();
               
        }
       
        

        public async Task<Abonnement> GetAbonnement(int? id)
        {
            return _dbContext.Abonnements.Find(id);
        }

       
        public void AddAbonnement(Abonnement abonnement)
        {
            _dbContext.Abonnements.Add(abonnement);
            _dbContext.SaveChanges();
        }


        public async Task UpdateAbonnement(Abonnement abonnement)
        {
            _dbContext.Abonnements.Update(abonnement);
            _dbContext.SaveChanges();
        }
        public async Task<int> DeleteAbonnement(int id)
        {
            var abonnement = _dbContext.Abonnements.FirstOrDefault(x => x.idAbonnement == id);
            if (abonnement != null)
            {
                _dbContext.Abonnements.Remove(abonnement);

            }
            return _dbContext.SaveChanges();
        }

        public List<Abonnement> GetAbonnementByContenu(string word)
        {
            List<Abonnement> abs = new List<Abonnement>();
            foreach(Abonnement ab in _dbContext.Abonnements)
            {
                 if (ab.contenu.Contains(word))
                        abs.Add(ab);
                
            }
            return abs;
        }
    }
}
