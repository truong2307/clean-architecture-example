using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Application.Common.Interfaces;
using QuizApp.Domain.IRepository;
using QuizApp.Infrastructure.Identity;
using QuizApp.Infrastructure.Persistence;
using QuizApp.Infrastructure.Persistence.Repositories;
using System.Text;

namespace QuizApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WiQuizDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("WiQuizConnectionString"),
                   b => b.MigrationsAssembly(typeof(WiQuizDbContext).Assembly.FullName)));

            ConfigureIdentity(services);
            ConfigureJWT(services, configuration);

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IQuizFavouriteRepository, QuizFavouriteRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IStudentInClassRoomRepository, StudentInClassRoomRepository>();

            return services;
        }

        private static void ConfigureJWT(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var key = configuration.GetSection("Secret").GetSection("key").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                };
            });
        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<WiQuizDbContext>();
        }
    }
}
