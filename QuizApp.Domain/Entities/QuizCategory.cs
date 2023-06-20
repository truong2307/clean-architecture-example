using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class QuizCategory : Entity
    {
        public string Name { get; private set; }

        public QuizCategory(string name)
        {
            Name = name;
        }
    }
}
