using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class QuizFavouriteEntityTypeConfiguration : IEntityTypeConfiguration<QuizFavourite>
    {
        public void Configure(EntityTypeBuilder<QuizFavourite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property<int>("_quizId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("QuizId")
               .IsRequired();

            builder.Property<string>("_userId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("UserId")
               .IsRequired();

            builder.Property(x => x.Created)
              .IsRequired();

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.Updated)
                .IsRequired(false);

            builder.Property(x => x.UpdatedBy);
        }
    }
}
