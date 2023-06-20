using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class QuizEntityTypeConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(126);

            builder.Property(x => x.Description)
                .HasMaxLength(512);

            builder.Property(x => x.TypeOfPublish)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property<int>("_quizCategoryId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("QuizCategoryId")
               .IsRequired();

            builder.Property(x => x.Created)
               .IsRequired();

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.Updated)
                .IsRequired(false);

            builder.Property(x => x.UpdatedBy);

            builder.HasOne(x => x.QuizCategory)
               .WithMany()
               .HasForeignKey("_quizCategoryId");

            builder.HasMany(x => x.QuizQuestions)
                .WithOne()
                .HasForeignKey("_quizId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.QuizFavourites)
                .WithOne()
                .HasForeignKey("_quizId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.QuizAnswers)
                .WithOne()
                .HasForeignKey("_quizId")
                .OnDelete(DeleteBehavior.Cascade);

            var navigation = builder.Metadata.FindNavigation(nameof(Quiz.QuizQuestions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigation2 = builder.Metadata.FindNavigation(nameof(Quiz.ClassRooms));
            navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigation3 = builder.Metadata.FindNavigation(nameof(Quiz.QuizFavourites));
            navigation3.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigation4 = builder.Metadata.FindNavigation(nameof(Quiz.QuizAnswers));
            navigation4.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
