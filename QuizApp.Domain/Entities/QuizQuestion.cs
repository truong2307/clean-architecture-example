using QuizApp.Domain.Enums;
using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class QuizQuestion : BaseAuditableEntity
    {
        private int _quizId;

        public string QuestionTitle { get; private set; }

        public int TypeOfQuestion { get; private set; }

        public string ContentQuestion { get; private set; }

        public QuizQuestion() { }

        public QuizQuestion(string questionTitle
                            , QuizTypeOfQuestion typeOfQuestion
                            , string contentQuestion
                            , int quizId, string createdBy)
        {
            QuestionTitle = questionTitle;
            QuestionTitle = contentQuestion;
            _quizId = quizId;
            TypeOfQuestion = typeOfQuestion.Id;
            Created = DateTime.Now;
            CreatedBy = createdBy;
        }
    }
}
