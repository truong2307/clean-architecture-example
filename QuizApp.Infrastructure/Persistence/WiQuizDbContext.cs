using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entities;
using QuizApp.Domain.SeedWork;
using QuizApp.Infrastructure.Identity;
using QuizApp.Infrastructure.Persistence.EntityConfigurations;

namespace QuizApp.Infrastructure.Persistence
{
    public class WiQuizDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public WiQuizDbContext(DbContextOptions<WiQuizDbContext> options) : base(options) { }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassRoomCategory> ClassRoomCategories { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<QuizCategory> QuizCategories { get; set; }
        public DbSet<QuizFavourite> QuizFavourites { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<StudentInClassRoom> StudentInClassRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClassRoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClassRoomCategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuizEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuizAnswerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuizCategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuizFavouriteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuizQuestionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentInClassRoomEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
