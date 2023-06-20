using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class QuizAnswerEntityTypeConfiguration : IEntityTypeConfiguration<QuizAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAnswer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property<int>("_quizId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("QuizId")
               .IsRequired();

            builder.Property<int>("_questionId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("QuestionId")
               .IsRequired();

            builder.Property<string>("_studentId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("StudentId")
               .IsRequired();

            builder.Property(x => x.ContentAnswer)
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
