using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class QuizAnswer : BaseAuditableEntity
    {
        private int _quizId;
        private int _questionId;
        private string _studentId;

        public string ContentAnswer { get; private set; }

        public QuizAnswer(int quizId, int questionId, string studentId, string contentAnswer, string createdBy)
        {
            _quizId = quizId;
            _questionId = questionId;
            _studentId = studentId;
            ContentAnswer = contentAnswer;
            Created = DateTime.Now;
            CreatedBy = createdBy;
        }
    }
}
