using QuizApp.Domain.Enums;
using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class Quiz : BaseAuditableEntity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public int TypeOfPublish { get; private set; }

        private int _quizCategoryId;
        public QuizCategory QuizCategory { get; private set; }

        private List<QuizQuestion> _quizQuestions;
        public IEnumerable<QuizQuestion> QuizQuestions => _quizQuestions.AsReadOnly();

        protected Quiz()
        {
            _quizQuestions = new List<QuizQuestion>();
        }

        public Quiz(string title, string description, int quizCategoryId, string createdBy) : this()
        {
            Title = title;
            Description = description;
            _quizCategoryId = quizCategoryId;
            TypeOfPublish = ClassRoomTypeOfPublish.Private.Id;
            Created = DateTime.Now;
            CreatedBy = createdBy;
        }

        public void PublishInternal()
        {
            TypeOfPublish = ClassRoomTypeOfPublish.PublicInternal.Id;
        }

        public void PublishExternal()
        {
            TypeOfPublish = ClassRoomTypeOfPublish.PublicExternal.Id;
        }

        public void Hide()
        {
            TypeOfPublish = ClassRoomTypeOfPublish.Private.Id;
        }

        public void AddQuestion(QuizQuestion question)
        {
            _quizQuestions.Add(question);
        }

        public void AddRangeQuestion(List<QuizQuestion> questions)
        {
            _quizQuestions.AddRange(questions);
        }
    }
}
