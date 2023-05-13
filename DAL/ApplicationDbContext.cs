using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entities;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace DAL
{//class used to access data through entity framework
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        //créer un constructeur public
        public ApplicationDbContext(IConfiguration configuration,DbContextOptions<ApplicationDbContext> options) : base(options)
         {
            Configuration = configuration;
        }
     /*public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {/*configurer la bd*/
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApp"));
            //optionsBuilder.UseNpgsql("WebApp");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<CartePaiement> CartePaiements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
       
        //connect to postgresql db
      
 

         

        

        
    }
}
