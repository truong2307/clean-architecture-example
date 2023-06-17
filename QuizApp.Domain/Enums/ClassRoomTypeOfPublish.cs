using QuizApp.Domain.SeedWork;

namespace QuizApp.Domain.Enums
{
    public class ClassRoomTypeOfPublish
        : Enumeration
    {
        public static ClassRoomTypeOfPublish Private = new(1, nameof(Private));
        public static ClassRoomTypeOfPublish PublicInternal = new(2, nameof(PublicInternal));
        public static ClassRoomTypeOfPublish PublicExternal = new(3, nameof(PublicExternal));

        public ClassRoomTypeOfPublish(int id, string name)
            : base(id, name) { }
    }
}
