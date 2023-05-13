using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DocumentFormat.OpenXml.Drawing;
using Entities;

namespace DAL.Classes
{
    public class FactureRepository : IFactureRepository
    {
        public ApplicationDbContext _dbContext;
        public FactureRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        

        public async Task<Facture> GetFacture(int? idFacture)
        {
            return _dbContext.Factures.Find(idFacture);
        }

        public IEnumerable<Facture> GetFactures()
        {
            return _dbContext.Factures.ToList();
        }

        public async Task UpdateFacture(Facture facture)
        {
            _dbContext.Factures.Update(facture);
            _dbContext.SaveChanges();
        }

        public void AddFacture(Facture facture)
        {
            _dbContext.Factures.Add(facture);
            _dbContext.SaveChanges();
        }
        public async Task<int> DeleteFacture(int id)
        {
            var facture = _dbContext.Factures.FirstOrDefault(x => x.idFacture == id);
            if (facture != null)
            {
                _dbContext.Factures.Remove(facture);

            }
            return _dbContext.SaveChanges();
        }

        public Task<Facture> GetFactFromUser(string name)
        {
            throw new NotImplementedException();
        }
    }
}
