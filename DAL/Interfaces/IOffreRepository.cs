using Entities;

namespace DAL.Interfaces
{
    public interface IOffreRepository
    {
        IEnumerable<Offre> GetOffres();
        
        // int? signifie que la valeur peut de int peut etre null
        Task <Offre> GetOffre(int? idOffre);
        void AddOffre(Offre offre);
        Task<int> DeleteOffre(int idOffre);

        Task UpdateOffre(Offre offre);
        List<Offre> GetOffreByContenu(string word);
    }
}
