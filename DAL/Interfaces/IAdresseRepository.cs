using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdresseRepository
    {
        IEnumerable<Adresse> GetAdresses();
        Task<Adresse> GetAdresse(int? id);
        void AddAdresse(Adresse adresse);
        Task<int> DeleteAdresse(int id);

        Task UpdateAdresse(Adresse adresse);
    }
}
