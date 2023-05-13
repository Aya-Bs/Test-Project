using DAL;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
//apres installer "Install-Package Microsoft.Extensions.Configuration
//Install - Package Microsoft.Extensions.Configuration.FileExtensions
//Install-Package Microsoft.Extensions.Configuration.Json
//ajouter les directives using
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using DAL.Interfaces;
using DAL.Classes;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        //ce que j'ai ajout� encore pour configuratuion de la base : 
        // Cr�er un objet ConfigurationBuilder
        var configBuilder = new ConfigurationBuilder();

        // Ajouter une source de configuration � partir d'un fichier JSON
        configBuilder.AddJsonFile("appsettings.json");

        // Construire la configuration
        var configuration = configBuilder.Build();

        // Add services to the container.
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        //inject automapper inside application (tell the app that we have to read the app we are created
        builder.Services.AddAutoMapper(typeof(Program).Assembly);




        //apres ma correction , j'ai trouv� du probleme dans configuration 
        // alors : Le mot "Configuration" dans la ligne de code que je vous ai donn�e se r�f�re � une instance de l'interface IConfiguration, qui est utilis�e pour acc�der aux valeurs de configuration dans ASP.NET Core.
        //pour cela je vais faire des modifs et chaque modif va etre apport� par un message pour clarifier les choses 
        //ajouter EF 
        //let the application know what context xe are using to talk to our data base 
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("WebApp")));
        builder.Services.AddScoped<IOffreRepository, OffreRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAbonnementRepository, AbonnementRepository>();
        builder.Services.AddScoped<IAdresseRepository, AdresseRepository>();
        builder.Services.AddScoped<IFactureRepository, FactureRepository>();
        builder.Services.AddScoped<ICarteRepository, CarteRepository>();
        //cet ligne de code est normalement faite pour lier les deux mis en <> mais j'ai trouv� probeleme
        //l'appel de la m�thode "AddNewtonsoftJson()" du package "Microsoft.AspNetCore.Mvc.NewtonsoftJson"
        builder.Services.AddControllers().AddNewtonsoftJson();

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}