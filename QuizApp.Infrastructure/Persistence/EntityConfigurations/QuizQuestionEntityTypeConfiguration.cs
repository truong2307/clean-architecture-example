using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class QuizQuestionEntityTypeConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property<int>("_quizId")
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("QuizId")
              .IsRequired();

            builder.Property(x => x.QuestionTitle)
                .IsRequired()
                .HasMaxLength(126);

            builder.Property(x => x.TypeOfQuestion)
                .IsRequired();

            builder.Property(x => x.ContentQuestion)
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
