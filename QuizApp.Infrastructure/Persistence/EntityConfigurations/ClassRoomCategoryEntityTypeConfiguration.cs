using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class ClassRoomCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ClassRoomCategory>
    {
        public void Configure(EntityTypeBuilder<ClassRoomCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(126);
        }
    }
}
