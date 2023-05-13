using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICarteRepository
    {
        IEnumerable<CartePaiement> GetCartes();
        Task<CartePaiement> GetCarte(int? id);
        void AddCarte(CartePaiement carte);
        Task<int> DeleteCarte(int id);

        Task UpdateCarte(CartePaiement carte);
    }
}
