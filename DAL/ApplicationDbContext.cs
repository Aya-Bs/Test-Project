using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entities;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace DAL
{//class used to access data through entity framework
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        //créer un constructeur public
        public ApplicationDbContext(IConfiguration configuration,DbContextOptions<ApplicationDbContext> options) : base(options)
         {
            Configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
     /*public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {/*configurer la bd*/
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApp"));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //optionsBuilder.UseNpgsql("WebApp");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Offre> Offres { get; set; }
       
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<CartePaiement> CartePaiements { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Abonnement>().HasData(
                
                new Abonnement {idAbonnement=1, prixAbonnement = 6, nomAb= "Basic", nombreAchat = 0, isActive = true, dateDebut = new DateTime(2023, 06, 01), dateFin = new DateTime(2023, 07, 01), contenu = "films / music / podcasts / audible books", description="" },
                new Abonnement { idAbonnement = 2, prixAbonnement = 10, nomAb = "Pro", nombreAchat = 0, isActive = true, dateDebut = new DateTime(2023, 06, 01), dateFin = new DateTime(2023, 07, 01), contenu = "films / music / podcasts / audible books", description = "" },
                new Abonnement { idAbonnement = 3, prixAbonnement = 15, nomAb = "Mega", nombreAchat = 0, isActive = true, dateDebut = new DateTime(2023, 06, 01), dateFin = new DateTime(2023, 07, 01), contenu = "films / music / podcasts / audible books", description = "" }

                );
           
           
        }
       
        //connect to postgresql db
      
 

         

        

        
    }
}
