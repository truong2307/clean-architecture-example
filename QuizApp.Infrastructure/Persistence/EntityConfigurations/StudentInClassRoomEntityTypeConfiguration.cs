using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class StudentInClassRoomEntityTypeConfiguration : IEntityTypeConfiguration<StudentInClassRoom>
    {
        public void Configure(EntityTypeBuilder<StudentInClassRoom> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property<string>("_studentId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("StudentId")
               .IsRequired();

            builder.Property<int>("_classRoomId")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("ClassRoomId")
               .IsRequired();
        }
    }
}
