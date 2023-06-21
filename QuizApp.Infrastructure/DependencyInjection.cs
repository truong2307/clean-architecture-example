using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Domain.IRepository;
using QuizApp.Infrastructure.Identity;
using QuizApp.Infrastructure.Persistence;
using QuizApp.Infrastructure.Persistence.Repositories;

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

            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IQuizFavouriteRepository, QuizFavouriteRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IStudentInClassRoomRepository, StudentInClassRoomRepository>();

            return services;
        }
    }
}
