using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFactureRepository
    {
        IEnumerable<Facture> GetFactures();
        Task<Facture> GetFacture(int? idFacture);
        void AddFacture(Facture facture);
        Task<int> DeleteFacture(int id);
        Task UpdateFacture(Facture facture);

        Task<Facture> GetFactFromUser(string name);


    }
}
