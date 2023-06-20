using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class ClassRoomCategory : Entity
    {
        public string Name { get; private set; }

        public ClassRoomCategory(string name)
        {
            Name = name;
        }
    }
}
