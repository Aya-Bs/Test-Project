using Entities;

namespace Business
{
    public interface ICarteService
    {
        void AddCarte(CartePaiement carte);
        Task DeleteCarte(int id);

        Task UpdateCarte(CartePaiement carte);
    }
}