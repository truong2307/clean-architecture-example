using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Domain.Entities;

namespace QuizApp.Infrastructure.Persistence.EntityConfigurations
{
    class ClassRoomEntityTypeConfiguration : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(126);

            builder.Property(x => x.HomeRoomTeacherId)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(512);

            builder.Property<int>("_classRoomCategoryId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ClassRoomCategoryId")
                .IsRequired();

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.Updated)
                .IsRequired(false);

            builder.Property(x => x.UpdatedBy);

            builder.HasOne(x => x.ClassRoomCategory)
               .WithMany()
               .HasForeignKey("_classRoomCategoryId");

            builder.HasMany(x => x.Quizzes)
                .WithMany(x => x.ClassRooms)
                .UsingEntity("QuizClassRoom",
                    l => l.HasOne(typeof(Quiz))
                            .WithMany()
                            .HasForeignKey("QuizId")
                            .HasPrincipalKey(nameof(Quiz.Id)),
                    r => r.HasOne(typeof(ClassRoom))
                            .WithMany()
                            .HasForeignKey("ClassRoomId")
                            .HasPrincipalKey(nameof(ClassRoom.Id)),
                    j => j.HasKey("QuizId", "ClassRoomId"));

            var navigation = builder.Metadata.FindNavigation(nameof(ClassRoom.Quizzes));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
