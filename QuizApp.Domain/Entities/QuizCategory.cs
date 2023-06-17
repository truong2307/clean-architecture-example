using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class QuizCategory : BaseAuditableEntity
    {
        public string Name { get; private set; }

        public QuizCategory() { }

        public QuizCategory(string name, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
            Created = DateTime.Now;
        }
    }
}
