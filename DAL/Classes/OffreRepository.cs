using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class OffreRepository : IOffreRepository
    {
        public ApplicationDbContext _dbContext;
        public OffreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
      
        public async Task<Offre> GetOffre(int? idOffre)
        {
           return _dbContext.Offres.Find(idOffre);
        }

        public IEnumerable<Offre> GetOffres()
        {
            return _dbContext.Offres.ToList();
        }

        public void AddOffre(Offre offre)
        {
            _dbContext.Offres.Add(offre);
            _dbContext.SaveChanges();

        }
        public async Task UpdateOffre(Offre offre)
        {
            _dbContext.Offres.Update(offre);
            _dbContext.SaveChanges();
        }
        public async Task<int> DeleteOffre(int id_offre)
        {
            
            try
            {
                var offre = _dbContext.Offres.FirstOrDefault(x => x.idOffre == id_offre);
                if (offre != null)
            {
                    _dbContext.Offres.Remove(offre);
  
            }

            }catch (Exception e)
            {
                Console.WriteLine("offre non existante");
            }
            
            return _dbContext.SaveChanges();

        }


    }
}
