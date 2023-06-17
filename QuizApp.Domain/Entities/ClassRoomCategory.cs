using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class ClassRoomCategory : BaseAuditableEntity
    {
        public string Name { get; private set; }

        public ClassRoomCategory() { }

        public ClassRoomCategory(string name, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
            Created = DateTime.Now;
        }
    }
}
