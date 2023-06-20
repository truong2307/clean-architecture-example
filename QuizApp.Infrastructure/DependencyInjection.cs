using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Infrastructure.Identity;
using QuizApp.Infrastructure.Persistence;

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

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WiQuizDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
