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

        public ClassRoom() { }

        public ClassRoom(string name, string homeRoomTeacherId, string description, int classRoomCategoryId, string createdBy)
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
