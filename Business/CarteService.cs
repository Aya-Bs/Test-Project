
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CarteService : ICarteService
    {
        private readonly ICarteRepository carteRepository;
        public CarteService(ICarteRepository carteRepo)
        {
            carteRepository = carteRepo;
        }
        public void AddCarte(CartePaiement carte)
        {
            carteRepository.AddCarte(carte);
        }

        public async Task DeleteCarte(int id)
        {
            carteRepository.DeleteCarte(id);
        }

        public async Task UpdateCarte(CartePaiement carte)
        {
            carteRepository.UpdateCarte(carte);
        }
    }


}
