using MediatR;
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
        private readonly IMediator _mediator;

        public WiQuizDbContext(DbContextOptions<WiQuizDbContext> options) : base(options) { }

        public WiQuizDbContext(DbContextOptions<WiQuizDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
        }

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
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
