using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Entities
{
    public class ClassRoom : BaseAuditableEntity
    {
        public string Name { get; private set; }

        public string HomeRoomTeacherId { get; private set; }

        public string Description { get; private set; }

        private int _classRoomCategoryId;
        public ClassRoomCategory ClassRoomCategory { get; private set; }

        private List<Quiz> _quizzes;
        public IEnumerable<Quiz> Quizzes => _quizzes.AsReadOnly();

        protected ClassRoom()
        {
            _quizzes = new List<Quiz>();
        }

        public ClassRoom(string name,
            string homeRoomTeacherId,
            string description,
            int classRoomCategoryId,
            string createdBy) : this()
        {
            Name = name;
            HomeRoomTeacherId = homeRoomTeacherId;
            Description = description;
            _classRoomCategoryId = classRoomCategoryId;
            Created = DateTime.Now;
            CreatedBy = createdBy;
        }

    }
}
