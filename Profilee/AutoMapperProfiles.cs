namespace Profiles
{
    using AutoMapper;
    using Modele_Donnee = Entities;
    using Modele_de_domaine;

    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() {
            //mappage entre Mdedomaine.User et MdeDonnee.User
            CreateMap<User, Modele_Donnee.User>().ReverseMap();
            CreateMap<Adresse, Modele_Donnee.Adresse>().ReverseMap();




        }

    }
}