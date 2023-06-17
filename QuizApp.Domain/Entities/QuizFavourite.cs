using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class QuizFavourite : BaseAuditableEntity 
    {
        private int _quizId;
        private string _userId;

        public QuizFavourite(int quizId, string userId)
        {
            _quizId = quizId;
            _userId = userId;
            Created = DateTime.Now;
            CreatedBy = userId;
        }
    }
}
