using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Enums
{
    public class QuizTypeOfQuestion : Enumeration
    {
        public static QuizTypeOfQuestion MultipleChoice = new(1, nameof(MultipleChoice));
        public static QuizTypeOfQuestion Essay = new(2, nameof(Essay));

        public QuizTypeOfQuestion(int id, string name)
            : base(id, name) { }
    }
}
