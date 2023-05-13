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
    public class AdresseRepository : IAdresseRepository
    {
        public ApplicationDbContext _dbContext;
        public AdresseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public void AddAdresse(Adresse adresse)
        {
            _dbContext.Adresses.Add(adresse);
            _dbContext.SaveChanges();
        }

        public async Task<int> DeleteAdresse(int id)
        {
            var adresse = _dbContext.Adresses.FirstOrDefault(x => x.idPays == id);
            if (adresse != null)
            {
                _dbContext.Adresses.Remove(adresse);

            }
            return _dbContext.SaveChanges();

        }

        public async Task<Adresse> GetAdresse(int? id)
        {
            return _dbContext.Adresses.Find(id);
        }

        public IEnumerable<Adresse> GetAdresses()
        {
            return _dbContext.Adresses.ToList();
        }

        public async Task UpdateAdresse(Adresse adresse)
        {
            _dbContext.Adresses.Update(adresse);
            _dbContext.SaveChanges();
        }
    }
}
