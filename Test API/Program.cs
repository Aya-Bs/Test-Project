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

using Helpers;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Business;
using Stripe;

using EmailService;
using Microsoft.AspNetCore.Identity;
using Entities;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DAL.Interfaces;
using DAL.Classes;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;


public class Program
{
    public static void Main(string[] args)
    {





        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        //ce que j'ai ajouté encore pour configuratuion de la base : 
        // Créer un objet ConfigurationBuilder
        var configBuilder = new ConfigurationBuilder();

        // Ajouter une source de configuration à partir d'un fichier JSON
        configBuilder.AddJsonFile("appsettings.json");

        // Construire la configuration
        var configuration = configBuilder.Build();



        // Add services to the container.
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        /***************************/
        builder.Services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));

        StripeConfiguration.ApiKey = configuration.GetValue<string>("StripeSettings:SecretKey");
        builder.Services
            .AddScoped<CustomerService>()
                .AddScoped<ChargeService>()
                .AddScoped<TokenService>();







        //inject automapper inside application (tell the app that we have to read the app we are created
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        //on va utiliser CORS
        //le front va lancer l'application sur +eurs ports et retourner les rq ==> CORS va interdire les requétes prevenants d'autre ports  

        builder.Services.AddCors(option =>
        {
            option.AddDefaultPolicy(policy =>
            {
               policy
                .WithOrigins(new[] { "http://localhost:50363", "http://localhost:8080", "http://localhost:4200", "http://localhost:5253" })
                
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();//permettre l'envoi des cookies vers le front
            });
        }
            );

      /*  builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
        ValidIssuer = configuration["Token:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false,
    };
});*/
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Token:Issuer"],
            ValidAudience = configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"]))
        };
    });
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
       .AddCookie(options =>
       {
           options.Cookie.Name = "YourCookieName"; // Définissez le nom du cookie ici
           options.Cookie.HttpOnly = true; // Spécifiez si le cookie est accessible uniquement par HTTP
           options.Cookie.SameSite = SameSiteMode.Strict; // Définissez la politique SameSite du cookie
           options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Définissez la politique de sécurité du cookie
           options.ExpireTimeSpan = TimeSpan.FromDays(7); // Définissez la durée de validité du cookie
           options.SlidingExpiration = true; // Activez l'expiration de session glissante
       });



        //Pour l'inscription avec google
        //on installe le pckg authetication.google 
        //on ajoute la ligne suivante
        /*builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = configuration["App:GoogleClientID"];
                options.ClientId = configuration["App:GoogleClientSecret"];
            });*/

        //allez vers Console.developers.goole -> apis -> credentials -> créer projet

        //apres ma correction , j'ai trouvé du probleme dans configuration 
        // alors : Le mot "Configuration" dans la ligne de code que je vous ai donnée se réfère à une instance de l'interface IConfiguration, qui est utilisée pour accéder aux valeurs de configuration dans ASP.NET Core.
        //pour cela je vais faire des modifs et chaque modif va etre apporté par un message pour clarifier les choses 
        //ajouter EF 
        //let the application know what context xe are using to talk to our data base 
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("WebApp")));
        //çvd que l'interface IOR est un type de OR
        builder.Services.AddScoped<IOffreRepository, OffreRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
       // builder.Services.AddScoped<IAbonnementRepository, AbonnementRepository>();
        builder.Services.AddScoped<IFactureRepository, FactureRepository>();
        builder.Services.AddScoped<ICarteRepository, CarteRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        //builder.Services.AddScoped<IAbonnementService, AbonnementService>();
        builder.Services.AddScoped<ICarteService, CarteService>();
        builder.Services.AddScoped<IMultimediaService, MultimediaService>();
        builder.Services.AddScoped<IMultimediaRepository, MultimediaRepository>();
        builder.Services.AddScoped<IEmailSender, EmailSender>();
        builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

        //configurer JwtService en tant que service
        builder.Services.AddScoped<JwtService>();

        builder.Services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();



        var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
        builder.Services.AddSingleton(emailConfig);
        //l'appel de la méthode "AddNewtonsoftJson()" du package "Microsoft.AspNetCore.Mvc.NewtonsoftJson"
        builder.Services.AddControllers().AddNewtonsoftJson();
        
        var app = builder.Build();

        //je veux configurer le webhook 


        void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Utilisez cette méthode pour mapper les contrôleurs

                endpoints.MapControllerRoute(
                    name: "webhook",
                    pattern: "/Payment/Webhook",
                    defaults: new { controller = "Payment", action = "HandleWebhook" });
            });
        }



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        /*  app.UseCors(options => options
          .WithOrigins(new [] {})
          .AllowAnyHeader()
          .AllowAnyMethod()
           
          );*/
        app.UseCors();
       
        app.UseAuthorization();
        app.UseAuthentication();
        app.MapControllers();

        app.Run();
    }



}