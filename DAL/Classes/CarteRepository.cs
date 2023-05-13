using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL.Classes
{
    public class CarteRepository : ICarteRepository
    {
        public ApplicationDbContext _dbContext;
        public CarteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<CartePaiement> GetCarte(int? id)
        {
            return _dbContext.CartePaiements.Find(id);
        }

        public IEnumerable<CartePaiement> GetCartes()
        {
            return _dbContext.CartePaiements.ToList();
        }
        public void AddCarte(CartePaiement carte)
        {
            _dbContext.CartePaiements.Add(carte);
            _dbContext.SaveChanges();
        }

        public async Task UpdateCarte(CartePaiement carte)
        {
            _dbContext.CartePaiements.Update(carte);
            _dbContext.SaveChanges();
        }
        public async Task<int> DeleteCarte(int id)
        {
            var carte = _dbContext.CartePaiements.FirstOrDefault(x => x.idCvvCvc == id);
            if (carte != null)
            {
                _dbContext.CartePaiements.Remove(carte);

            }
            return _dbContext.SaveChanges();

        }
    }
}
